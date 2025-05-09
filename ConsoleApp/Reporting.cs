using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Reporting
    {
        private readonly Warehouse warehouse;

        public Reporting(Warehouse warehouse)
        {
            this.warehouse = warehouse ?? throw new ArgumentNullException(nameof(warehouse));
        }

        public void RegisterIncome(Product product, string unit, int quantity)
        {
            Console.WriteLine($"Income invoice:");
            Console.WriteLine($" - Product: {product.Name}");
            Console.WriteLine($" - Quantity: {quantity} {unit}");
            Console.WriteLine($" - Date/Time: {DateTime.Now:dd.MM.yyyy HH:mm}");

            warehouse.AddProduct(product, unit, quantity, DateTime.Now);
        }

        public void RegisterShipment(string productName, int quantity)
        {
            Console.WriteLine($"Shipment invoice:");
            Console.WriteLine($" - Product: {productName}");
            Console.WriteLine($" - Quantity: {quantity}");
            Console.WriteLine($" - Date/Time: {DateTime.Now:dd.MM.yyyy HH:mm}");

            warehouse.ShipProduct(productName, quantity);
        }

        public void GenerateInventoryReport()
        {
            Console.WriteLine($"\nInventory as at {DateTime.Now:dd.MM.yyyy}");
            warehouse.DisplayInventory();
        }
    }
}
