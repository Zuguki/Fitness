using System;
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
            var userGender = new Gender(GetUserData("Please enter the gender of user: "));
            var userBirthYear = DateTime.Parse(GetUserData("Please enter user birth day: "));
            var userWeigh = double.Parse(GetUserData("Please enter the weight of user: "));
            var userHeight = double.Parse(GetUserData("Please enter the height of user: "));

            var userController = new UserController(userName, userGender, userBirthYear, userWeigh, userHeight);
            userController.Save();
        }

        private static string GetUserData(string message)
        {
            Console.Write(message);
            var result = Console.ReadLine();
            Console.Clear();

            return result;
        }
    }
}