using DAL.SQLContexts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class AdminRepo
    {
        private readonly ISQLContext SQLContext = new SQLContext();

        public void CreateShow(Show show) => SQLContext.CreateShow(show);

        public void CreateCinema(Cinema cinema) => SQLContext.CreateCinema(cinema);
    }
}
