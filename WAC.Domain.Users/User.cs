using System;

namespace WAC.Domain.Users
{
    public class User
    {
        public int Id { get; private set; }

        private string username;
        private string Username { 
            get {
                return username;
            }
            set {
                if(!string.IsNullOrWhiteSpace(value)) {
                    username = value;
                } else {
                    throw new Exception();
                }
            } 
        }
        
        private string password;
        private string Password {
            get {
                return password;
            }
            set {
                if(!string.IsNullOrWhiteSpace(value)) {
                    password = value;
                } else {
                    throw new Exception();
                }
            } 
        }

        private int Age { get; set;}

        protected User() {
        }

        public User(string username, string password, int age) {
            Username = username;
            Password = password;
            Age = age;
        }
    }
}
