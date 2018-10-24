using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Killerapp.ViewModels.AdminViewModels
{
    public class MakeShowViewModel
    {
        [Required]
        [Display(Name = "Cinema")]
        public string CinemaName { get; set; }

        [Required]
        [Display(Name = "MovieHallNumber")]
        public int MovieHallNumber { get; set; }

        [Required]
        [Display(Name = "Movie")]
        public string MovieName { get; set; }

        [Required]
        [Display(Name = "DateTime")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }


    }
}
