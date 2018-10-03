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
        OrderViewModel orderViewModel;
        public IActionResult MovieInfo()
        {
            orderViewModel = new OrderViewModel
            {
                Cinemas = orderLogic.GetCinemas()
            };
            return View(orderViewModel);
        }
    }
}