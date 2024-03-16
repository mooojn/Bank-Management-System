using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MainBusinessApp
{
    internal class UserDL
    {
        public static List<User> Users = new List<User>();

        public static void SignUp(string name, string pass)
        {   
            UtilUi.Process();
            Program.connection.Open();
            // insert vals into db
            string query = "INSERT INTO Users (name, password, cash) VALUES (@name, @pass, 0)";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@pass", pass);
            
            cmd.ExecuteNonQuery();
            
            Program.connection.Close();
            UtilUi.Success("You have successfully signed up");
        }
        public static bool PassValidated(string name, string pass)
        {
            bool flag = false;
            Program.connection.Open();
            
            string query = "SELECT * FROM Users WHERE Name = @name AND Password = @pass";
            
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@pass", pass);
                
            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read()) {
                flag = true;
                Program.currentUserId = Convert.ToInt32(reader["userId"]);  // setting current user id
            }
            Program.connection.Close();
            
            return flag;
        }
        public static bool UniqueUser(string name)
        {
            bool flag = false;
            Program.connection.Open();
            // checking if user exists
            string query = "SELECT * FROM Users WHERE Name = @name";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@name", name);
            
            SqlDataReader reader = cmd.ExecuteReader();
            // if user does not exist
            if (!reader.Read())
                flag = true;
            
            Program.connection.Close();

            return flag;
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
