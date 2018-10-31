using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class AdminLogic
    {
        private AdminRepo adminRepo = new AdminRepo();

        public void CreateShow(Show show) => adminRepo.CreateShow(show);

        public void CreateCinema(Cinema cinema) => adminRepo.CreateCinema(cinema);
    }
}
