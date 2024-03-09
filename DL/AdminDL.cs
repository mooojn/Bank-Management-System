using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainBusinessApp
{
    internal class AdminDL
    {
        Bank bank = new Bank("Azure Bank", "admin");
        public static bool ValidatePassword(string pass)
        {
            return pass == "admin";
        }
    }
}
