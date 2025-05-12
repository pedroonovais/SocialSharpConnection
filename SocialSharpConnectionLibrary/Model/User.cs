using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Model
{
    public class User
    {
        public long id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string username { get; set; }

        public User() { }

        public User(long id, string name, int age, string email, string username)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.email = email;
            this.username = username;
        }

        public long GetId() => id;
        public string GetName() => name;
        public int GetAge() => age;
        public string GetEmail() => email;
        public string GetUsername() => username;
    }
}

