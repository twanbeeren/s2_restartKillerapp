using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Killerapp.ViewModels.Order
{
    public class PickChairViewModel
    {
        public List<Ticket> Tickets { get; set; }
        public MovieHall MovieHall{ get; set; }
    }
}
