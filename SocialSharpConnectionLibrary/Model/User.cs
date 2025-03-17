using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.model
{
    public class User
    {
        protected long id { get; }
        protected string name { get; }
        protected int age { get; }
        protected string email { get; }
        protected string username { get; }

        internal User(string name, int age, string email, string username)
        {
            this.id = Random.Shared.NextInt64();
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

