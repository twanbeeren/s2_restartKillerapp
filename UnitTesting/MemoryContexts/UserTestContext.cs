using DataInterfaces.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UnitTesting.MemoryContexts
{
    class UserTestContext : IUserContext
    {
        List<User> users = new List<User>();
        
        public List<User> UsersSeed()
        {
            users.Add(new User(1, "Twan", "Password", "twanbeeren@mail.com", 18, false));
            users.Add(new User(2, "Twen", "Wachtwoord", "twanbeeren@gmail.com", 18, false));

            return users;
        }

        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserOnId(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Login(string email, string password)
        {
            int counter = users.Where(u => u.Email == email && u.Password == password).Count();
            if(counter == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Register(User user)
        {
            users.Add(user);
        }
    }
}
