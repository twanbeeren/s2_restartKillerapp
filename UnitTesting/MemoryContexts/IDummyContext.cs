using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.MemoryContexts
{
    interface IDummyContext
    {
        User GetUser();

        List<Cinema> GetCinemas();

        List<Show> GetShows();
    }
}
