using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Ticket
    {
        public Show Show { get; private set; }
        public User User { get; private set; }
        public Chair Chair { get; set; }

        public Ticket(User user, Show show)
        {
            User = user;
            Show = show;
        }
        public Ticket(Show show)
        {
            Show = show;
        }
        
    }
}
