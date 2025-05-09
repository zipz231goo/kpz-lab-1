using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Product
    {
        public string Name { get; private set; }
        public Money Price { get; private set; }
        public Category? Category { get; private set; }

        public Product(string name, Money price, Category? category = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price ?? throw new ArgumentNullException(nameof(price));
            Category = category;
        }

        public void SetPrice(Money newPrice)
        {
            Price = newPrice ?? throw new ArgumentNullException(nameof(newPrice));
        }

        public void DecreasePrice(Money amount)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));

            int totalCurrent = Price.GetWholePart() * 100 + Price.GetFractionalPart();
            int totalDecrease = amount.GetWholePart() * 100 + amount.GetFractionalPart();

            if (totalDecrease > totalCurrent)
                throw new InvalidOperationException("Cannot decrease price below zero.");

            int totalResult = totalCurrent - totalDecrease;
            int newWhole = totalResult / 100;
            int newFraction = totalResult % 100;

            Price = new Money(newWhole, newFraction);
        }

        public void SetCategory(Category category)
        {
            Category = category;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Product: {Name}");
            if (Category != null)
            {
                Category.Display();
            }
            Console.Write("Price: ");
            Price.Display();
            Console.Write("--------------------\n");
        }
    }
}
