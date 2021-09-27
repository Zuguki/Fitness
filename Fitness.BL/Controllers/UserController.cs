using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Models;

namespace Fitness.BL.Controllers
{
    public class UserController
    {
        public User User { get; }

        public UserController(string name, Gender gender, DateTime birthDay, double weight, double height)
        {
            User = new User(name, gender, birthDay, weight, height);
        }
        
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                User = formatter.Deserialize(fs) as User;
            }
            // TODO: Что делать если пользователя не прочитали?
        }
        
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }

            Console.WriteLine("Users Data was saved");
        }
    }
}