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
            MakeShowViewModel model = new MakeShowViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult MakeShow(MakeShowViewModel model)
        {
            try
            {
                Show show = new Show(model.MovieHall, model.Movie, model.Date, model.Price);
                adminLogic.MakeShow(show);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //[HttpPost]
        //public IActionResult GetAvailableShowtimes(MakeShowViewModel model)
        //{
        //    List<Show> shows = adminLogic.GetAvailableShows(model.MovieHall);

        //}
    }
}