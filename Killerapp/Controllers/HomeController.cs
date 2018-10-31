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
        MovieLogic movieLogic = new MovieLogic();
        UserLogic userLogic = new UserLogic();
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel
            {
                Movies = movieLogic.GetMovies()
            };
            if (HttpContext.Session.IsAvailable)
            {
                int id = HttpContext.Session.GetInt32("Id").GetValueOrDefault(0);
                string name = HttpContext.Session.GetString("Name");
                string email = HttpContext.Session.GetString("Email");
                model.CurrentUser = userLogic.GetUser(email);
                model.Admin = HttpContext.Session.GetInt32("Admin").GetValueOrDefault(0);
                return View(model);
            }
            return View(model);
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
