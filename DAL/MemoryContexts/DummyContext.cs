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
            List<Cinema> cinemas = new List<Cinema>
            {
                new Cinema("Pathé", "Amsterdam"),
                new Cinema("Foroxity", "Sittard"),
                new Cinema("Pathé", "Maastricht")
            };
            return cinemas;
        }

        public List<Show> GetShows()
        {
            List<Show> shows = new List<Show>
            {
                new Show(new Cinema("Pathé", "Amsterdam"), new Movie("Deadpool 2", Models.Enumerations.Genre.Action, 110, DateTime.Now, Models.Enumerations.AgeRestriction.Twelve, 4), DateTime.Now)
            };
            return shows;
        }
    }
}
