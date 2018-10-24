using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Killerapp.ViewModels.UserViewModels;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;

namespace Killerapp.Controllers
{
    public class LoginController : Controller
    {
        const string SessionKeyName = "Name";
        const string SessionKeyId = "Id";
        private UserLogic userLogic = new UserLogic();
        private RegisterViewModel registerViewModel;
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(userLogic.CheckLogin(model.Email, model.Password))
            {
                //User has to be made in SQLContext
                User CurrentUser = new User();
                CurrentUser = userLogic.GetUser(model.Email);
                HttpContext.Session.SetString(SessionKeyName, CurrentUser.Name);
                HttpContext.Session.SetInt32(SessionKeyId, CurrentUser.Id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Register()
        {
            registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            User user = new User(model.Name, model.Password, model.Email, model.Age, model.Admin);
            try
            {
                userLogic.Register(user);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Login", "Login");
        }
    }
}