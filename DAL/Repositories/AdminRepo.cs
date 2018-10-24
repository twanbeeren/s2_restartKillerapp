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

        public void MakeShow(Show show) => SQLContext.MakeShow(show);
    }
}
