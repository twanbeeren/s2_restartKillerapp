using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLContexts
{
    interface ISQLContext
    {
        bool Login(string name, string password);
        User GetUser(int userId);
        List<Movie> GetMovies();
        List<Cinema> GetCinemas();
        List<Show> GetShows(int movieId);
    }
}
