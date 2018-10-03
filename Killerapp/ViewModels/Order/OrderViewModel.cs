using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Killerapp.ViewModels.Order
{
    public class OrderViewModel
    {
        public List<Cinema> Cinemas { get; set; }
    }
}
