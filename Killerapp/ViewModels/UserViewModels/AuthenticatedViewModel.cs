using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Killerapp.ViewModels.UserViewModels
{
    public class AuthenticatedViewModel
    {
        public User CurrentUser { get; set; }

        public int Admin { get; set; }
    }
}
