using DAL.SQLContexts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
   public  class UserRepo
   {
        private readonly IUserContext UserContext = new UserContext();

        public bool Login(string email, string password) => UserContext.Login(email, password);
        public void Register(User user) => UserContext.Register(user);
        public User GetUser(string email) => UserContext.GetUser(email);
        public User GetUserOnId(int id) => UserContext.GetUserOnId(id);
    }
}
