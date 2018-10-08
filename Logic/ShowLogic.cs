using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ShowLogic
    {
        private DummyRepo repo = new DummyRepo();

        public List<Show> GetShows() => repo.GetShows();
    }
}
