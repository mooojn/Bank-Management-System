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
        public static int currentUserId = -1;   // -1 means no user is logged in
        public static string con = "Data Source=DESKTOP-AJHCE58\\MOOOJN;Initial Catalog=Azure-Bank;Integrated Security=True";
        public static SqlConnection connection = new SqlConnection(con);
        static void Main(string[] args)
        {
            // main choices
            const string ADMIN_LOGIN = "1";
            const string USER_SIGN_IN = "2";
            const string USER_SIGN_UP = "3";
            const string EXIT = "4";
            // user choices
            const string CHECK_PORTFOLIO = "1";
            const string DEPOSIT_CASH = "2";
            const string WITHDRAW_CASH = "3";
            const string BLOCK_TRANSACTIONS = "4";
            const string DELETE_ACCOUNT = "5";
            const string USER_LOGOUT = "6";
            // admin choices
            const string ADD_USER = "1";
            const string VIEW_USERS = "2";
            const string CHANGE_USER_NAME = "3";
            const string DELETE_USER = "4";
            const string ADMIN_LOGOUT = "5";

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
                        return;   // end program

                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        adminLogin:
            while (true) {
                choice = MainUi.AdminMenu();
                switch (choice) {
                    case ADD_USER:
                        Console.WriteLine("Add New User");
                        Console.ReadKey();
                        break;

                    case VIEW_USERS:
                        Console.WriteLine("View Users");
                        Console.ReadKey();
                        break;

                    case CHANGE_USER_NAME:
                        Console.WriteLine("Change User Name");
                        Console.ReadKey();
                        break;

                    case DELETE_USER:
                        Console.WriteLine("Delete User");
                        Console.ReadKey();
                        break;

                    case ADMIN_LOGOUT:
                        goto logout;

                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        userLogin:
            while (true) {
                choice = MainUi.UserMenu();
                switch (choice) {
                    case CHECK_PORTFOLIO:
                        UserFunc.CheckPortfolio();
                        break;

                    case DEPOSIT_CASH:
                        UserFunc.DepositCash();
                        break;

                    case WITHDRAW_CASH:
                        UserFunc.WithdrawCash();
                        break;

                    case BLOCK_TRANSACTIONS:
                        Console.WriteLine("Block Transactions");
                        break;

                    case DELETE_ACCOUNT:
                        UserFunc.DeleteAccount();
                        goto logout;   // after deleting account, user is logged out

                    case USER_LOGOUT:
                        goto logout;

                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        }
    }
}
