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
        MovieHall GetMovieHallOnId(int movieHallId);
        Movie GetMovieOnId(int movieId);
        List<Movie> GetMovies();
        List<Cinema> GetCinemas();
        Show GetShowOnId(int showId);
        List<Show> GetShows(int movieId, int cinemaId);
        //Admin functions may need a special SQLContext
        void CreateShow(Show show);
        void CreateCinema(Cinema cinema);
    }
}
