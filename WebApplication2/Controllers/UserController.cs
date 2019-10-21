using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ASPToep.Models;
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
        private IUser userLogic = new UserLogic(false);

        public IActionResult Profile()
        {
            //INITIALIZE THE VIEWMODEL 
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

        [HttpPost]
        public IActionResult Profile(ProfileViewModel user)
        {
            User currentUser = userLogic.GetUserByName(HttpContext.User.Identity.Name);
            Error errorObject = userLogic.ValidateUpdate(currentUser, user.Username, user.Password);

            //IF THERE ARE NO ERRORS, UPDATE THE USER
            if (errorObject.GetErrorState() == 0)
            {
                //CONVERT VIEWMODEL TO MODEL
                User newUser = new User();
                newUser.UpdateUserInfo(user.Username, user.Firstname, user.Lastname);

                userLogic.UpdateUser(currentUser.Id, newUser);
                return View(user);
            }
            else
            {
                //CREATE ALL THE ERROR MESSAGES
                for (int i = 0; i < errorObject.errorKey.Count; i++)
                    ModelState.AddModelError(errorObject.errorKey[i], errorObject.errorMessage[i]);
                foreach (var error in ModelState.Values.SelectMany(m => m.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return View(user);
            }
        }
    }
}