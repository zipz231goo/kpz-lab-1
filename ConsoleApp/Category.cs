using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Category
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Category(string name, string description = "")
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be empty.");

            Name = name;
            Description = description;
        }

        public void Display()
        {
            Console.WriteLine($"Category: {Name}");
            if (!string.IsNullOrWhiteSpace(Description))
                Console.WriteLine($"Description: {Description}");
        }
    }
}
