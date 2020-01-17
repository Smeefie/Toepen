using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASPToep.Models;
using Exceptions;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ASPToep.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //LOAD THE PAGE
        private IUser userLogic = new UserLogic(true);
        public IActionResult Profile()
        {
            //INITIALIZE THE VIEWMODEL 
            if (userLogic.GetUserByName(HttpContext.User.Identity.Name) == null) return RedirectToAction("Login", "Session");
            User tempUser = userLogic.GetUserByName(HttpContext.User.Identity.Name);

            //CONVERT USER TO PROFILEVIEWMODEL
            ProfileViewModel tempUserVM = new ProfileViewModel()
            {
                Username = tempUser.Username,
                Firstname = tempUser.Firstname,
                Lastname = tempUser.Lastname,
                Email = tempUser.Email,
            };
            return View(tempUserVM);
        }

        [Route("User/Statistics")]
        public IActionResult Statistics()
        {
            StatisticsViewModel statisticsViewModel = new StatisticsViewModel()
            {
                StatList = userLogic.GetAllStats()
            };
           
            return View(statisticsViewModel);
        }

        //UPDATE THE USER
        [HttpPost]
        public IActionResult Profile(ProfileViewModel user)
        {
            User currentUser = userLogic.GetUserByName(HttpContext.User.Identity.Name);
            try
            {
                userLogic.ValidateUpdate(currentUser, user.Username, user.Password);
            }
            catch (UpdateUserException e)
            {
                //CREATE ALL THE ERROR MESSAGES   
                for (int i = 0; i < e.ErrorObject.errorKey.Count; i++)
                    ModelState.AddModelError(e.ErrorObject.errorKey[i], e.ErrorObject.errorMessage[i]);
                foreach (var error in ModelState.Values.SelectMany(m => m.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return View(user);
            }

            //CONVERT VIEWMODEL TO MODEL
            User newUser = new User();
            newUser.UpdateUserInfo(user.Username, user.Firstname, user.Lastname);

            userLogic.UpdateUser(currentUser.Id, newUser);
            return View(user);
        }

        #region FRIENDS - OUTSIDE OF SCOPE FOR NOW
        //public IActionResult AddFriend(string friend)
        //{
        //    userLogic.AddFriend(int.Parse(User.Claims.Single(i => i.Type == "Id").Value), friend);

        //    int id = int.Parse(User.Claims.Single(i => i.Type == "Id").Value);
        //    var friends = new List<FriendViewModel>();
        //    var friendlist = userLogic.GetFriends(id);
        //    if (friendlist.Count() > 0) friendlist.ToList().ForEach(x => friends.Add(new User(x.Username, x.id)));

        //    return PartialView("Razor/FriendsPartial", friends.ToArray());
        //}

        //public IActionResult DeleteFriend(string friend)
        //{
        //    userLogic.DeleteFriend(int.Parse(User.Claims.Single(i => i.Type == "Id").Value), int.Parse(friend));

        //    int id = int.Parse(User.Claims.Single(i => i.Type == "Id").Value);
        //    var friends = new List<FriendViewModel>();
        //    var friendlist = userLogic.GetFriends(id);
        //    if (friendlist.Count() > 0) friendlist.ToList().ForEach(x => friends.Add(new FriendViewModel(x.Username, x.id)));

        //    return PartialView("Razor/FriendsPartial", friends.ToArray());
        //}

        //public JsonResult ValidateFriend(string friend)
        //{
        //    return Json(userLogic.ValidateFriend(int.Parse(User.Claims.Single(i => i.Type == "Id").Value), friend));
        //}
        #endregion
    }
}