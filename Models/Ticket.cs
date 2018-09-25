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

        public Ticket(User user, Show show, Chair chair)
        {
            User = user;
            Show = show;
            Chair = chair;
        }
        public Ticket(Show show, Chair chair)
        {
            Show = show;
            Chair = chair;
        }
        
    }
}
