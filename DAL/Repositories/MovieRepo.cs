using System;
using System.Collections.Generic;
using System.Text;
using DAL.SQLContexts;
using Models;

namespace DAL.Repositories
{
    public class MovieRepo
    {
        private readonly ISQLContext SQLContext = new SQLContext();

        public Movie GetMovieOnId(int movieId) => SQLContext.GetMovieOnId(movieId);
        public List<Movie> getMovies() => SQLContext.GetMovies();
    }
}
