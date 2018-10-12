using DAL.Repositories;
using Models;
using System;

namespace Logic
{
    public class UserLogic
    {
        private DummyRepo Repo = new DummyRepo();

        public bool Login(string name, string password)
        {
            if(Repo.GetUser().Name == name && Repo.GetUser().Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
