using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainBusinessApp
{
    internal class Program
    {
        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-AJHCE58\\MOOOJN;Initial Catalog=Azure-Bank;Integrated Security=True");
        static void Main(string[] args)
        {
            // choices
            const string ADMIN_LOGIN = "1";
            const string USER_SIGN_IN = "2";
            const string USER_SIGN_UP = "3";
            const string EXIT = "4";
            
            // START
        logout:  // used to logout from admin or user
            string choice = "";
            
            // main loop
            while (true) {
                choice = MainUi.Menu();
                switch (choice) {
                    case ADMIN_LOGIN:
                        MainUi.Header();
                        string pass = AdminUi.GetPassword();
                        
                        UtilUi.Process();
                        // admin password is correct
                        if (AdminDL.ValidatePassword(pass)) {
                            UtilUi.Success("Authentication was Successful");
                            goto adminLogin;
                        }
                        else {
                            UtilUi.Error("Invalid Password");
                            break;
                        }
                    case USER_SIGN_IN:
                        MainUi.Header();
                        string userName = UserUi.GetName();
                        // user exist in db
                        if (!UserDL.UniqueUser(userName)) {   
                            string userPass = UserUi.GetPassword();

                            UtilUi.Process();
                            // user exist and password is correct
                            if (UserDL.PassValidated(userName, userPass)) {   
                                UtilUi.Success("Authentication was Successful");
                                goto userLogin;
                            }
                            else {
                                UtilUi.Error("Invalid Password");
                                break;
                            }
                        }
                        else {
                            UtilUi.Error("User does not exist...");
                            break;
                        }
                    case USER_SIGN_UP:
                        MainUi.Header();
                        string name = UserUi.GetName();
                        // userName is unique so SignUp
                        if (UserDL.UniqueUser(name)) {
                            string password = UtilUi.GetMaskedInput();   // as user unique so getting password
                            UserDL.SignUp(name, password);
                        }
                        else
                            UtilUi.Error("User already exists.");
                        break;
                    case EXIT:
                        return; // end program
                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        adminLogin:
            while (true) {
                choice = MainUi.AdminMenu();
                switch (choice) {
                    case "1":
                        Console.WriteLine("Add New User");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("View Users");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Change User Name");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Delete User");
                        Console.ReadKey();
                        break;
                    case "5":
                        goto logout;
                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        userLogin:
            while (true)
            {
                choice = MainUi.UserMenu();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Check Portfolio");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("Deposit Cash");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("Withdraw Cash");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Block Transactions");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("Delete Account");
                        Console.ReadKey();
                        break;
                    case "6":
                        goto logout;
                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        }
    }
}
