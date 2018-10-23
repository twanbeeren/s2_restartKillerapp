using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Killerapp.ViewModels.UserViewModels;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Killerapp.Controllers
{
    public class LoginController : Controller
    {
        const string SessionKeyName = "Name";
        const string SessionKeyId = "Id";
        private UserLogic userLogic;
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            userLogic = new UserLogic();
            if(userLogic.CheckLogin(model.Email, model.Password))
            {
                HttpContext.Session.SetString(SessionKeyName, userLogic.GetUser(model.Email).Name);
                HttpContext.Session.SetInt32(SessionKeyId, userLogic.GetUser(model.Email).Id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}