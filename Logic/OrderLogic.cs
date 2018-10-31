using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class OrderLogic
    {
        private CinemaRepo CinemaRepo  = new CinemaRepo();

        public List<Cinema> GetCinemas() => CinemaRepo.GetCinemas();

    }
}
