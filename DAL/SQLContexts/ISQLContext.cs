using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLContexts
{
    interface ISQLContext
    {
        bool Login(string email, string password);
        void Register(User user);
        User GetUser(string email);
        List<Movie> GetMovies();
        List<Cinema> GetCinemas();
        List<Show> GetShows(int movieId);
        //Admin functions may need a special SQLContext
        void MakeShow(Show show);
    }
}
