using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterfaces.Interfaces
{
    public interface IShowContext
    {
        Show GetShowOnId(int showId);
        List<Show> GetShows(int movieId, int cinemaId);
    }
}
