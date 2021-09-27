using System;
using System.Data;
using Fitness.BL.Controllers;
using Fitness.BL.Models;

namespace Fitness
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fitness Application");

            var userName = GetUserData("Please enter the name of user: ");

            var userController = new UserController(userName);
            if (userController.IsNewUser)
            {
                var userGender = new Gender(GetUserData("Please enter the gender of user: "));
                var userBirthDate = BirthDateParse("Please enter user birth day: ");
                var userWeigh = DoubleParse("Please enter the weight of user: ");
                var userHeight = DoubleParse("Please enter the height of user: ");
                
                userController.SetNewUserData(userName, userGender, userBirthDate, userWeigh, userHeight);
            }

            Console.WriteLine($"Hello: {userController.CurrentUser}");
        }

        private static string GetUserData(string message)
        {
            Console.Write(message);
            var result = Console.ReadLine();
            Console.Clear();

            return result;
        }

        private static DateTime BirthDateParse(string message)
        {
            DateTime dt;
            do
            {
                Console.Write(message);
                var result = Console.ReadLine();

                if (DateTime.TryParse(result, out dt))
                    break;
                Console.WriteLine("UnCorrect DateTime");
            } while (true);
            
            Console.Clear();
            return dt;
        }
        
        private static double DoubleParse(string message)
        {
            double d;
            do
            {
                Console.Write(message);
                var result = Console.ReadLine();

                if (double.TryParse(result, out d))
                    break;
                Console.WriteLine("UnCorrect double");
            } while (true);
            
            Console.Clear();
            return d;
        }
    }
}