﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Killerapp.ViewModels.UserViewModels
{
    public class IndexViewModel
    {
        public User CurrentUser { get; set; }

        public int Admin { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
