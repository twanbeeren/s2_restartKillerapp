using DAL.MemoryContexts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class DummyRepo
    {
        private readonly IDummyContext dummyContext = new DummyContext();

        public User GetUser() => dummyContext.GetUser();

        public List<Cinema> GetCinemas() => dummyContext.GetCinemas();
    }
}
