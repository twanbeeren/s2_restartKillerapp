using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Killerapp.ViewModels.OrderViewModels
{
    public class ChooseShowViewModel
    {
        public Movie Movie { get; set; }
        public List<Cinema> Cinemas { get; set; }

        public List<Show> Shows { get; set; }
    }
}
