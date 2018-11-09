﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLContexts
{
    interface IUserContext
    {
        bool Login(string email, string password);
        void Register(User user);
        User GetUser(string email);
        User GetUserOnId(int userId);
    }
}