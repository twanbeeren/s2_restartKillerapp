using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Killerapp.ViewModels.AdminViewModels
{
    public class CreateCinemaViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Company { get; set; }

        [Required]
        [Display(Name = "Place")]
        public string Place { get; set; }

        
    }
}
