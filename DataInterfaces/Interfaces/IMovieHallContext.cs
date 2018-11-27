using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterfaces.Interfaces
{
    public interface IMovieHallContext
    {
        MovieHall GetMovieHallOnId(int moviehallId);
    }
}
