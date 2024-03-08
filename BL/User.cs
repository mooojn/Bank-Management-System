using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MainBusinessApp
{
    internal class User
    {
        // objs
        private string name;
        private string password;
        private int cash;
        private List<History> history;
        // constructor for initializing
        public User(string name, string pass)
        {
            this.name = name;
            password = pass;
            cash = 0;  // default val
        }
        public bool AddCash(int depositAmount)
        {
            // error encountered so returning
            if (depositAmount < 0)
                return false;
            // adding cash
            cash += depositAmount;
            return true;
        }
        public bool WithdrawCash(int withdrawAmount)
        {
            // error encountered so returning
            if (withdrawAmount < 0 || withdrawAmount > cash)
                return false;
            // withdrawing cash
            cash -= withdrawAmount;
            return true;
        }
        public void ShowCash()
        {
            Console.Write($"Your total cash holdings holding: ${cash}");
        }
    }
}
