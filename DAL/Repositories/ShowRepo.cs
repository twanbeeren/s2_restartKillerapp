using DAL.SQLContexts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class ShowRepo
    {
        private readonly ISQLContext SQLContext = new SQLContext();

        public List<Show> GetShows(int movieId, int cinemaId) => SQLContext.GetShows(movieId, cinemaId);
    }
}
