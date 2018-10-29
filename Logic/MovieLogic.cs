using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using Models;

namespace Logic
{
    public class MovieLogic
    {
        private MovieRepo movieRepo = new MovieRepo();
        public Movie GetMovieOnId(int movieId) => movieRepo.GetMovieOnId(movieId);
        public List<Movie> getMovies() => movieRepo.getMovies();
    }
}
