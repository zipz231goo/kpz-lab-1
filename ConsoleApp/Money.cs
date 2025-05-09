using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Money
    {
        private int wholePart;     
        private int fractionalPart;

        public Money(int whole, int fractional)
        {
            SetAmount(whole, fractional);
        }

        public void SetAmount(int whole, int fractional)
        {
            if (fractional >= 100)
            {
                whole += fractional / 100;
                fractional = fractional % 100;
            }

            if (fractional < 0 || whole < 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }

            wholePart = whole;
            fractionalPart = fractional;
        }

        public int GetWholePart() => wholePart;
        public int GetFractionalPart() => fractionalPart;

        public void Display()
        {
            Console.WriteLine($"{wholePart} UAH {fractionalPart:D2} COP");
        }
    }
}
