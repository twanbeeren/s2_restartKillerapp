using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Killerapp.ViewModels.Order;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace Killerapp.Controllers
{
    public class OrderController : Controller
    {
        OrderLogic orderLogic = new OrderLogic();
        ShowLogic showLogic = new ShowLogic();
        public IActionResult MovieInfo()
        {
            ChooseShowViewModel model = new ChooseShowViewModel
            {
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