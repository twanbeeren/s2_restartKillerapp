using DAL.Repositories;
using Models;
using System;

namespace Logic
{
    public class UserLogic
    {
        private DummyRepo Repo = new DummyRepo();
        private UserRepo userRepo = new UserRepo();

        public bool CheckLogin(string name, string password) => userRepo.Login(name, password);

        public User GetUser(string email) => userRepo.GetUser(email);

        public void Register(User user) => userRepo.Register(user);
        
    }
}
