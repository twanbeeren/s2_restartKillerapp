using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ShowLogic
    {
        private ShowRepo Repo = new ShowRepo();
        public List<Show> GetShows(int movieId, int cinemaId) => Repo.GetShows(movieId, cinemaId);
    }
}
