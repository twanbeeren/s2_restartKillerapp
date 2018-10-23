using DAL.SQLContexts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
   public  class UserRepo
   {
        private readonly ISQLContext SQLContext = new SQLContext();

        public bool Login(string email, string password) => SQLContext.Login(email, password);
        public User GetUser(string email) => SQLContext.GetUser(email);
    }
}
