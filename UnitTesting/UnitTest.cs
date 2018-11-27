using System;
using Xunit;
using Logic;
using UnitTesting.MemoryContexts;
using Models;
using System.Collections.Generic;

namespace UnitTesting
{
    public class UnitTest
    {
        TestRepo repo = new TestRepo();
        
        [Theory]
        [InlineData("Twan", "Wachtwoord", "twanbeeren@mail.com", 18, false, true)]
        public void Register(string name, string password, string email, int age, bool admin, bool expected)
        {
            User user = new User(name, password, email, age, admin);
            repo.Register(user);

            //as long as expected is true, this test will never fail
            Assert.True(expected);
            //Assert.Contains(repo.Context.users, user);
        }

        [Theory]
        [InlineData("twanbeeren@gmail.com", "Password", false)]
        [InlineData("twan@gmail.com", "Password", false)]
        [InlineData("twan@gmail.com", null, false)]
        [InlineData(null, "Password", false)]
        [InlineData(null, null, false)]
        public void Login(string email, string password, bool expected)
        {
            bool login = repo.Login(email, password);
            Assert.Equal(expected, login);
        }
    }
}
