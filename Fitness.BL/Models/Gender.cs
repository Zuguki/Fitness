using System;

namespace Fitness.BL.Models
{
    [Serializable]
    public class Gender
    {
        public string Name { get; }
        
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