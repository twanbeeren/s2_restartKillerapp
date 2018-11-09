using DAL.Repositories;
using Models;
using System;

namespace Logic
{
    public class UserLogic
    {
        private UserRepo userRepo = new UserRepo();

        public bool CheckLogin(string name, string password) => userRepo.Login(name, password);

        public User GetUser(string email) => userRepo.GetUser(email);
        public User GetUserOnId(int id) => userRepo.GetUserOnId(id);
        public void Register(User user) => userRepo.Register(user);
        
    }
}
