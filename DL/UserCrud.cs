using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MainBusinessApp
{
    internal class UserCrud
    {
        public static List<User> Users = new List<User>();

        public static bool SignIn(string name, string pass)
        {
            // validating
            UtilUi.Process();
            if (!UniqueUser(name) && pass_validated(name, pass))
            {
                Console.WriteLine("You are signed in...");
                UtilUi.PressAnyKey();
                return true;
            }
            else
                UtilUi.Error("Incorrect Password");
            return false;
        }
        public static void SignUp(string name, string pass)
        {
            if (UniqueUser(name)) // checking if user is unique
            {
                UtilUi.Success("You have successfully signed up");

                User Usr = new User(name, pass);
                Users.Add(Usr);
            }
            else
                UtilUi.Error("User already exists.");
        }
        public static void ViewAllUsers()
        {
            int i = 0;

            Console.WriteLine("Index\tName\tCash");
            foreach(User Usr in Users)
            {
                //Console.WriteLine($"{i}\t{Usr.name}\t{Usr.cash}");
                i++;
            }
        }
        public static bool pass_validated(string name, string pass)
        {
            int i = 0;
            foreach(User Usr in Users)
            {
                ////if (Usr.name == name && Usr.password == pass)
                ////{
                ////    Program.current_user_index = i;
                //    return true;
                //}
                i++;
            }
            return false;
        }
        public static bool UniqueUser(string name)
        {
            foreach (User Usr in Users)
            {
                //if (Usr.name == name)
                //{
                //    return false;
                //}
            }
            return true;
        }
        public static void DeleteUserFromIndex(int index_to_remove)
        {
            UtilUi.Process();
            
            Users.RemoveAt(index_to_remove);
            
            UtilUi.Success("Account has been removed...");
        }
        public static bool ValidateIndex(int indexToValidate)
        {
            return indexToValidate + 1 > Users.Count;
        }
    }
}
