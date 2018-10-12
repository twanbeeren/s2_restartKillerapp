using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ShowLogic
    {
        private DummyRepo Repo = new DummyRepo();
        
        public List<Show> GetShows() => Repo.GetShows();
    }
}
