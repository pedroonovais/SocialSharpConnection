using library.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.controller
{
    public static class UserController
    {
        public static User CreateUser(string name, int age, string email, string username)
        {
            return new User(name, age, email, username);
        }
    }
}
