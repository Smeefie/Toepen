using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPToep.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Logic;
using Logic.Interfaces;
using Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using Exceptions;

namespace ASPToep.Controllers
{
    public class SessionController : Controller
    {
        private ISession userLogic = new UserLogic(true);

        #region LOGIN + LOGOUT
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel userVM)
        {
            //CHECK THE LOGIN CREDENTIALS
            User user = new User(userVM.Username, userVM.Password);
            try
            {
                userLogic.ValidateLogin(user);
            }
            catch(ValidateException e)
            {
                ModelState.AddModelError("", e.Message);
                return View(userVM);
            }

           //CREATE CLAIMS
           var claims = new List<Claim>
           {
               new Claim("id", user.Id.ToString()),
               new Claim(ClaimTypes.Name, user.Username),
               new Claim("Role", user.Role.ToString())
           };

           var claimsIdentity = new ClaimsIdentity(
               claims, CookieAuthenticationDefaults.AuthenticationScheme);

           await HttpContext.SignInAsync(
               CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { });

           return RedirectToAction(actionName: "Profile", controllerName: "User");            
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        #endregion

        #region REGISTER  
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        //REGISTER THE USER
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            try
            {
                userLogic.Register(new User(-1, user.Username, user.Firstname, user.Lastname, user.Password, user.Email));
            }
            catch(RegisterException e)
            {
                //CREATE ERROR MESSAGES
                for (int i = 0; i < e.ErrorObject.errorKey.Count; i++)
                    ModelState.AddModelError(e.ErrorObject.errorKey[i], e.ErrorObject.errorMessage[i]);
                foreach (var error in ModelState.Values.SelectMany(m => m.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return View(user);
            }

            await Login(new LoginViewModel(user.Username, user.Password));
            return RedirectToAction(actionName: "Profile", controllerName: "User");

        }
        #endregion
    }
}