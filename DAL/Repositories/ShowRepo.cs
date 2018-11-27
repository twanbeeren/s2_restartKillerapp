using DAL.SQLContexts;
using DataInterfaces.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class ShowRepo
    {
        private readonly IShowContext Context = new ShowContext();

        public List<Show> GetShows(int movieId, int cinemaId) => Context.GetShows(movieId, cinemaId);

        public Show GetShowOnId(int showId) => Context.GetShowOnId(showId);
    }
}
