using System;
using System.IO;

namespace Fitness.BL.Models
{
    [Serializable]
    public class User
    {
        public string Name { get; }
        public Gender Gender { get; }
        public DateTime BirthDay { get; }
        public double Weight { get; }
        public double Height { get; }

        public User(string name, Gender gender, DateTime birthDay, double weight, double height)
        {
            #region Checking for correctness
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException($"Name can't be empty or null", nameof(name));
            if (gender == null)
                throw new ArgumentNullException($"Gender can't be null", nameof(gender));
            if (birthDay < DateTime.Parse("01.01.1990") ||  birthDay > DateTime.Now)
                throw new InvalidDataException($"You couldn't have been born at that time: {birthDay.Date}");
            if (weight <= 0)
                throw new ArgumentException($"Weight cannot be 0 or less", nameof(weight));
            if (height <= 0)
                throw new ArgumentException($"Height cannot be 0 or less", nameof(height));
            #endregion
            
            Name = name;
            Gender = gender;
            BirthDay = birthDay;
            Weight = weight;
            Height = height;
        }

        public int GetAge()
        {
            return DateTime.Now.Year - BirthDay.Year;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}