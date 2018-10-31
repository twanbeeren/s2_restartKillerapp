using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Killerapp.ViewModels.OrderViewModels;
using Killerapp.ViewModels.UserViewModels;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

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
            };
            return View(model);
        }

        [Route("api/order")]
        [HttpGet]
        public IActionResult Shows(int movieId, int cinemaId)
        {
            List<Show> shows = showLogic.GetShows(movieId, cinemaId);
            var json = JsonConvert.SerializeObject(shows);
            return Json(json);
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