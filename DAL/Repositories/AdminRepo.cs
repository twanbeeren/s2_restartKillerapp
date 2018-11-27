using DAL.SQLContexts;
using DataInterfaces.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class AdminRepo
    {
        private readonly IAdminContext Context = new AdminContext();

        public void CreateShow(Show show) => Context.CreateShow(show);

        public void CreateCinema(Cinema cinema) => Context.CreateCinema(cinema);
    }
}
