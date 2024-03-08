using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainBusinessApp
{
    internal class MainUi
    {
        public static string Menu()
        {
            Console.Clear();
            // welcome message
            Console.WriteLine("......Welcome to the Bank......\n");
            // menu
            Console.WriteLine("1. Sign-in as an Administrator");
            Console.WriteLine("2. Sign-in as a User");
            Console.WriteLine("3. Sign-up as a User");

            Console.WriteLine("4. Exit");

            // input
            return UtilUi.GetChoice();
        }
        public static string UserMenu()
        {
            Console.Clear();
            // menu
            Console.WriteLine("1. Check Portfolio");
            Console.WriteLine("2. Deposit Cash");
            Console.WriteLine("3. Withdraw Cash");
            Console.WriteLine("4. Block Transactions");
            Console.WriteLine("5. Delete Account");

            Console.WriteLine("6. Logout");

            // getting input
            return UtilUi.GetChoice();
        }
        public static string AdminMenu()
        {
            Console.Clear();
            // menu
            Console.WriteLine("1. Add New User");
            Console.WriteLine("2. View Users");
            Console.WriteLine("3. Change User Name");
            Console.WriteLine("4. Delete User");

            Console.WriteLine("5. Logout");

            // getting input
            return UtilUi.GetChoice();
        }
    }
}
