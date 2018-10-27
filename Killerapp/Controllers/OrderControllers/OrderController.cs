using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Killerapp.ViewModels.OrderViewModels;
using Killerapp.ViewModels.UserViewModels;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Killerapp.Controllers
{
    public class OrderController : Controller
    {
        OrderLogic orderLogic = new OrderLogic();
        ShowLogic showLogic = new ShowLogic();
        MovieLogic movieLogic = new MovieLogic();
        public IActionResult MovieInfo(int movieId)
        {
            ChooseShowViewModel model = new ChooseShowViewModel
            {
                Movie = movieLogic.GetMovieOnId(movieId),
                Cinemas = orderLogic.GetCinemas(),
                Shows = showLogic.GetShows()
            };
            return View(model);
        }

        public IActionResult PickChair()
        {
            PickChairViewModel model = new PickChairViewModel
            {
                //All the chairs must be set here from the logic class
            };
            return View(model);
        }
    }
}