using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Models;

namespace Fitness.BL.Controllers
{
    public class UserController
    {
        public List<User> Users { get; }
        public User CurrentUser { get; private set; }
        public bool IsNewUser { get; } = false;

        public UserController(string name)
        {
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == name);
            IsNewUser = (CurrentUser == null);
        }

        public void SetNewUserData(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            CurrentUser = new User(name, gender, birthDate, weight, height);
            Users.Add(CurrentUser);
            Save();
        }
        
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                    return users;
                return new List<User>();
            }
        }
        
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }

            Console.WriteLine("Users Data was saved");
        }
    }
}