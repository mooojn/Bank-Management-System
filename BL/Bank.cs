using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainBusinessApp
{
    internal class Bank
    {
        private string name;
        private string password;
        private List<User> users;
        
        private List<Asset> assets;
        public Bank(string name, string pass)
        {
            this.name = name;
            password = pass;
            users = new List<User>();
            assets = new List<Asset>();
        }   
    }
}
