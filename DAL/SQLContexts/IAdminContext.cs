using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLContexts
{
    interface IAdminContext
    {
        void CreateShow(Show show);
        void CreateCinema(Cinema cinema);
    }
}
