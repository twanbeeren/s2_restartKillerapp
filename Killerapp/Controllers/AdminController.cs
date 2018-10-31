using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Killerapp.ViewModels.AdminViewModels;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;

namespace Killerapp.Controllers
{
    public class AdminController : Controller
    {
        OrderLogic orderLogic = new OrderLogic();
        AdminLogic adminLogic = new AdminLogic();
        public IActionResult Index()
        {
            //Check if user is still logged in
            if(HttpContext.Session.GetInt32("Id").GetValueOrDefault(0) != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        [HttpGet]
        public IActionResult CreateCinema()
        {
            CreateCinemaViewModel model = new CreateCinemaViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCinema(CreateCinemaViewModel model)
        {
            try
            {
                Cinema cinema = new Cinema(model.Company, model.Place);
                adminLogic.CreateCinema(cinema);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpGet]
        public IActionResult CreateShow()
        {
            MakeShowViewModel model = new MakeShowViewModel
            {
                Cinemas = orderLogic.GetCinemas()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateShow(MakeShowViewModel model)
        {
            try
            {
                Show show = new Show(model.MovieHall, model.Movie, model.Date, model.Price);
                adminLogic.CreateShow(show);
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