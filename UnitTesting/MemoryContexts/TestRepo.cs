using DataInterfaces.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting.MemoryContexts
{
    class TestRepo
    {

        private readonly IUserContext UserContext = new UserTestContext();
        private readonly IAdminContext AdminContext = new AdminTestContext();

        //public List<User> SeedUsers() => Context.
        public bool Login(string email, string password) => UserContext.Login(email, password);
        public void Register(User user) => UserContext.Register(user);
        public User GetUser(string email) => UserContext.GetUser(email);
        public User GetUserOnId(int id) => UserContext.GetUserOnId(id);
    }
}
