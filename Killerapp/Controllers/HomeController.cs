using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Killerapp.Models;
using Logic;
using Models;
using Killerapp.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Http;

namespace Killerapp.Controllers
{
    public class HomeController : Controller
    {
        UserLogic userLogic = new UserLogic();
        RegisterViewModel registerViewModel;
        public IActionResult Index()
        {
            AuthenticatedViewModel model = new AuthenticatedViewModel();
            if (HttpContext.Session.IsAvailable)
            {
                int id = HttpContext.Session.GetInt32("Id").GetValueOrDefault(0);
                string name = HttpContext.Session.GetString("Name");
                User user = new User(id, name);
                model.CurrentUser = user;
                return View(model);
            }
            return View(model);
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
            //try{userLogic.Register(user);}
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
