using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.MemoryContexts
{
    class DummyContext : IDummyContext
    {
        User user;
        public User GetUser()
        {
            user = new User("Twan", "Password!", "twan@gmail.com", 18, false);
            return user;
        }

        public List<Cinema> GetCinemas()
        {
            List<Cinema> cinemas = new List<Cinema>();
            cinemas.Add(new Cinema("Pathé", "Amsterdam"));
            cinemas.Add(new Cinema("Foroxity", "Sittard"));
            cinemas.Add(new Cinema("Pathé", "Maastricht"));
            return cinemas;
        }
    }
}
