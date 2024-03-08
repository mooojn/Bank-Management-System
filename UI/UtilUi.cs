using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MainBusinessApp
{
    internal class UtilUi
    {
        public static void PressAnyKey()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
        public static void Error(string type)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(type);
            Console.ResetColor();
            PressAnyKey();
        }
        public static void Success(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
            PressAnyKey();
        }
        public static void InvalidChoice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Invalid Choice...");
            Console.ResetColor();
            Thread.Sleep(500);
        }
        public static void Process()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Processing please wait...");
            Console.WriteLine();
            Console.ResetColor();
            Thread.Sleep(800);
        }
        public static void ShowMSG(bool status)
        {
            Process();
            if (status)
                Success("Successfull...");
            else
                Error("Invalid amount");
        }
        public static string GetChoice()
        {
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        public static string GetMaskedInput()
        {
            Console.Write("Enter Password: ");
            string pass = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return pass;
        }
    }
}
