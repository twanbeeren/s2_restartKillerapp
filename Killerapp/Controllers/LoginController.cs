using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Killerapp.ViewModels.User;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Killerapp.Controllers
{
    public class LoginController : Controller
    {
        private UserLogic userLogic = new UserLogic();
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(userLogic.Login(model.Name, model.Password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}