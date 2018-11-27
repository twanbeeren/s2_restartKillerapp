using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterfaces.Interfaces
{
    public interface ICinemaContext
    {
        List<Cinema> GetCinemas();

        Cinema GetCinemaOnId(int cinemaId);
    }
}
