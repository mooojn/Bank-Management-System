using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainBusinessApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank("Azurje Bank", "admin");
            string choice = "";
            while (true)
            {
                choice = MainUi.Menu();
                switch (choice) 
                {
                    case "1":
                        MainUi.AdminMenu();
                        break;
                    case "2":
                        MainUi.UserMenu();
                        break;
                    case "3":
                        Console.WriteLine("signUP");
                        Console.ReadKey();
                        break;
                    case "4":
                        return; // end program
                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        }
    }
}
