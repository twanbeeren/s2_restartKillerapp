using DAL.Repositories;
using Models;
using System;

namespace Logic
{
    public class UserLogic
    {
        private DummyRepo repo = new DummyRepo();

        public bool Login(string name, string password)
        {
            if(repo.GetUser().Name == name && repo.GetUser().Password == password)
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
