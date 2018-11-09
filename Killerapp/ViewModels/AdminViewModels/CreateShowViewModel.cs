using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Killerapp.ViewModels.AdminViewModels
{
    public class CreateShowViewModel
    {
        [Required]
        [Display(Name = "Cinema")]
        public Cinema Cinema { get; set; }

        [Required]
        [Display(Name = "MovieHallNumber")]
        public MovieHall MovieHall { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public Movie Movie { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }

        public List<Cinema> Cinemas { get; set; }
    }
}
