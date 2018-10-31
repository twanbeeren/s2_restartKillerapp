using DAL.SQLContexts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CinemaRepo
    {
        private readonly ISQLContext SQLContext = new SQLContext();

        public List<Cinema> GetCinemas() => SQLContext.GetCinemas();
    }
}
