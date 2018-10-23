using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLContexts
{
    interface ISQLContext
    {
        bool Login(string email, string password);
        User GetUser(string email);
        List<Movie> GetMovies();
        List<Cinema> GetCinemas();
        List<Show> GetShows(int movieId);
    }
}
