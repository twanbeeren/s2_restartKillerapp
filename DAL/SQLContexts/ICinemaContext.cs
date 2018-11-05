using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLContexts
{
    interface ICinemaContext
    {
        List<Cinema> GetCinemas();
    }
}
