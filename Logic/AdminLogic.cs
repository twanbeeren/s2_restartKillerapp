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

        public void MakeShow(Show show) => adminRepo.MakeShow(show);
    }
}
