using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterfaces.Interfaces
{
    public interface IMovieContext
    {
        Movie GetMovieOnId(int movieId);
        List<Movie> GetMovies();
    }
}
