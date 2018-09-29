using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Killerapp.Models;
using Killerapp.ViewModels;
using Logic;
using Models;

namespace Killerapp.Controllers
{
    public class HomeController : Controller
    {
        UserLogic userLogic;
        RegisterViewModel registerViewModel;
        public IActionResult Index()
        {
            return View();
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
            return RedirectToAction("Login","Login");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
