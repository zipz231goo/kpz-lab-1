using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Warehouse
    {
        private class StockRecord
        {
            public Product Product { get; }
            public string Unit { get; }
            public int Quantity { get; private set; }
            public DateTime LastDeliveryDate { get; private set; }

            public StockRecord(Product product, string unit, int quantity, DateTime deliveryDate)
            {
                Product = product;
                Unit = unit;
                Quantity = quantity;
                LastDeliveryDate = deliveryDate;
            }

            public void AddStock(int quantity, DateTime deliveryDate)
            {
                if (quantity <= 0) throw new ArgumentException("Quantity must be positive.");
                Quantity += quantity;
                LastDeliveryDate = deliveryDate;
            }

            public void RemoveStock(int quantity)
            {
                if (quantity <= 0) throw new ArgumentException("Quantity must be positive.");
                if (quantity > Quantity) throw new InvalidOperationException("Not enough stock.");
                Quantity -= quantity;
            }

            public void Display()
            {
                Console.WriteLine($"Product: {Product.Name}, Unit: {Unit}, Quantity: {Quantity}");
                Console.Write("Price: ");
                Product.Price.Display();
                Console.WriteLine($"Date of last delivery: {LastDeliveryDate:dd.MM.yyyy}");
            }
        }

        private readonly List<StockRecord> stock = new();

        public void AddProduct(Product product, string unit, int quantity, DateTime deliveryDate)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            var existing = stock.FirstOrDefault(s => s.Product.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
            {
                existing.AddStock(quantity, deliveryDate);
            }
            else
            {
                stock.Add(new StockRecord(product, unit, quantity, deliveryDate));
            }
        }

        public void ShipProduct(string productName, int quantity)
        {
            var item = stock.FirstOrDefault(s => s.Product.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (item == null) throw new InvalidOperationException("Product not found.");
            item.RemoveStock(quantity);
        }

        public void DisplayInventory()
        {
            Console.WriteLine("=== Warehouse balances ===");
            foreach (var record in stock)
            {
                record.Display();
                Console.WriteLine("-------------------------");
            }
        }
    }
}
