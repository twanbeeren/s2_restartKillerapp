using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class OrderLogic
    {
        private DummyRepo repo = new DummyRepo();

        public List<Cinema> GetCinemas() => repo.GetCinemas();
        
    }
}
