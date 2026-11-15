using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Authentication
    {
        private string username = "admin";
        private string password;

        public Authentication(string password)
        {
            this.password = password;
        }

        public bool Login(string inputUsername, string inputPassword)
        {
            return inputUsername == username && inputPassword == password;
        }
    }
}
