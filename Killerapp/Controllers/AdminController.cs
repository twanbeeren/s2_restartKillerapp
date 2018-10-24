using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Killerapp.ViewModels.AdminViewModels;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Killerapp.Controllers
{
    public class AdminController : Controller
    {
        AdminLogic adminLogic = new AdminLogic();
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult MakeShow(MakeShowViewModel model)
        //{
        //    try
        //    {
        //        Show show = new Show();
        //        adminLogic.MakeShow(show);
        //        RedirectToAction("Index")
        //    }
        //    catch(Exception ex)
        //    {
        //        throw (ex);
        //    }
            
        //}
    }
}