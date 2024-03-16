using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainBusinessApp
{
    internal class UserFunc
    {
        public static void CheckPortfolio()
        {
            Program.connection.Open();
            
            string query = "Select Cash from Users where userId = @userId";

            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@userId", Program.currentUserId);
            SqlDataReader reader = cmd.ExecuteReader(); 
            
            if (reader.Read()) 
                Console.WriteLine("Cash: " + reader["Cash"]);
            Console.ReadKey();
            
            Program.connection.Close();
        }
        public static void DepositCash()
        {
            Program.connection.Open();
            
            Console.Write("Enter the amount to deposit: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            
            string query = "Update Users set Cash = Cash + @amount where userId = @userId";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@userId", Program.currentUserId);
            
            cmd.ExecuteNonQuery();
            
            Program.connection.Close();
            UtilUi.Success("Cash has been deposited");
        }
        public static void WithdrawCash()
        {
            Program.connection.Open();

            Console.Write("Enter the amount to withdraw: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            string query = "Update Users set Cash = Cash - @amount where userId = @userId";
            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@userId", Program.currentUserId);

            cmd.ExecuteNonQuery();

            Program.connection.Close();
            UtilUi.Success("Cash has been Withdrawn");
        }
        public static void DeleteAccount()
        {
            Program.connection.Open();

            string query = "DELETE FROM Users WHERE userId = @uid";

            SqlCommand cmd = new SqlCommand(query, Program.connection);
            cmd.Parameters.AddWithValue("@uid", Program.currentUserId);
            
            cmd.ExecuteNonQuery();

            Program.connection.Close();
        }
    }
}
