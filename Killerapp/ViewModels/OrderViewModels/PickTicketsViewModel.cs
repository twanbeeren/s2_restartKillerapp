using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Killerapp.ViewModels.OrderViewModels
{
    public class PickTicketsViewModel
    {
        public Show Show { get; set; }
        public List<User> InvitedFriends { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
