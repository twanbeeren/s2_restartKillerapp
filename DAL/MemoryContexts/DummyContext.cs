using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.MemoryContexts
{
    class DummyContext : IDummyContext
    {
        User user;
        public User GetUser()
        {
            user = new User("Twan", "Password!", "twan@gmail.com", 18, false);
            return user;
        }
    }
}
