using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public User User { get; private set; }
        public List<Ticket> Tickets { get; set; }
        public Order(User user, List<Ticket> tickets)
        {
            User = user;
            Tickets = tickets;
        }
        public Order(List<Ticket> tickets)
        {
            Tickets = tickets;
        }
    }
}
