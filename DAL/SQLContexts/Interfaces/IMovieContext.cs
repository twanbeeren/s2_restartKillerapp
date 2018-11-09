using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLContexts
{
    interface IMovieContext
    {
        MovieHall GetMovieHallOnId(int movieHallId);
        Movie GetMovieOnId(int movieId);
        List<Movie> GetMovies();
    }
}
