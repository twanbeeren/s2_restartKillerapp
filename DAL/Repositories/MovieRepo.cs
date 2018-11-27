using System;
using System.Collections.Generic;
using System.Text;
using DAL.SQLContexts;
using DataInterfaces.Interfaces;
using Models;

namespace DAL.Repositories
{
    public class MovieRepo
    {
        private readonly IMovieContext Context = new MovieContext();

        public Movie GetMovieOnId(int movieId) => Context.GetMovieOnId(movieId);
        public List<Movie> GetMovies() => Context.GetMovies();
    }
}
