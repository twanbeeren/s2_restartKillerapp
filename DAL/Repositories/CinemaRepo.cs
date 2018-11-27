using DAL.SQLContexts;
using DataInterfaces.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CinemaRepo
    {
        private readonly ICinemaContext Context = new CinemaContext();

        public List<Cinema> GetCinemas() => Context.GetCinemas();
        public Cinema GetCinema(int cinemaId) => Context.GetCinemaOnId(cinemaId);
    }
}
