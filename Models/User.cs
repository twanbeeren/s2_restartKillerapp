using System;

namespace Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public int Age { get; private set; }
        public bool Admin { get; private set; }

        public User()
        {

        }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public User(string name, string password, string email, int age, bool admin)
        {
            Name = name;
            Password = password;
            Email = email;
            Age = age;
            Admin = admin;
        }

        public User(int id, string name, string password, string email, int age, bool admin)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            Age = age;
            Admin = admin;
        }
    }
}
