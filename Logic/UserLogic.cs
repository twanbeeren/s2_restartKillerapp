using DAL.Repositories;
using Models;
using System;

namespace Logic
{
    public class UserLogic
    {
        private DummyRepo Repo = new DummyRepo();
        private UserRepo userRepo = new UserRepo();

        //public bool Login(string email, string password)
        //{
        //    if(Repo.GetUser().Email == email && Repo.GetUser().Password == password)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public bool CheckLogin(string name, string password) => userRepo.Login(name, password);

        public User GetUser(string email) => userRepo.GetUser(email);
    }
}
