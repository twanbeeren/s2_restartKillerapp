using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.MemoryContexts
{
    class DummyContext : IDummyContext
    {
        public User GetUser()
        {
            User user = new User("Twan", "Password!", "twan@gmail.com", 18, false);
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
                new Show(new Cinema("Pathé", "Amsterdam"), new Movie("Deadpool 2", Models.Enumerations.Genre.Action, 110, DateTime.Now, Models.Enumerations.AgeRestriction.Twelve, 4), DateTime.Now, 8.80)
            };
            return shows;
        }

        private List<Chair> MakeChairs()
        {
            List<Chair> chairs = new List<Chair>();
            int chairid = 1;
            for (int rownumber = 1; rownumber < 10; rownumber++)
            {
                for (int chairnumber = 1; chairnumber < 6; chairnumber++)
                {
                    chairs.Add(new Chair(Models.Enumerations.ChairType.Normal, chairid, chairnumber, rownumber));
                    chairid++;
                }
            }
            return chairs;
        }

        private List<Row> MakeRows()
        {
            List<Row> rows = new List<Row>();

            return rows;
        }

        //public MovieHall GetMovieHall()
        //{
        //    List<Chair> chairs = new List<Chair>();
        //    int chairid = 1;
        //    for (int rownumber = 1; rownumber < 10; rownumber++)
        //    {
        //        for (int chairnumber = 1; chairnumber < 6; chairnumber++)
        //        {
        //            chairs.Add(new Chair(Models.Enumerations.ChairType.Normal, chairid, chairnumber, rownumber));
        //            chairid++;
        //        }
        //    }
        //    chairs.Add(new Chair(Models.Enumerations.ChairType.Normal, 1, 1, 1));
        //    chairs.Add(new Chair(Models.Enumerations.ChairType.Normal, 2, 2, 1));
        //    chairs.Add(new Chair(Models.Enumerations.ChairType.Normal, 3, 3, 1));
        //    chairs.Add(new Chair(Models.Enumerations.ChairType.Normal, 4, 4, 1));
        //    List<Row> rows = new List<Row>();
        //    rows.Add(new Row(chairs));
        //    MovieHall movieHall = new MovieHall(rows, chairs.Count);
        //    return movieHall;
        //}
    }
}
