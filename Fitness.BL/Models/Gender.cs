using System;

namespace Fitness.BL.Models
{
    /// <summary>
    /// Class about Gender of User
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Gender name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Gender name</param>
        /// <exception cref="ArgumentNullException">Can't be empty or null</exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException($"Gender can't be empty or null", nameof(name));
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}