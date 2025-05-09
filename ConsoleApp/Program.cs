
using ConsoleApp;
using System;

class Program
{
    static void Main()
    {
        //Categories
        var beverageCategory = new Category("Beverage", "Liquid");
        var otherCategory = new Category("Other");

        //Products
        var milk = new Product("Milk", new Money(55, 50), beverageCategory);
        var sugar = new Product("Sugar", new Money(30, 50), otherCategory);
        var tea = new Product("Tea", new Money(55, 75), beverageCategory);
        var flour = new Product("Flour", new Money(40, 0), otherCategory);

        var warehouse = new Warehouse();
        var reporting = new Reporting(warehouse);

        // Incoming goods
        reporting.RegisterIncome(milk, "L", 100);
        reporting.RegisterIncome(sugar, "kg", 150);
        reporting.RegisterIncome(tea, "pack", 30);
        reporting.RegisterIncome(flour, "kg", 50);

        reporting.GenerateInventoryReport();

        Console.WriteLine("\nDiscount for milk.\n");
        var discount = new Money(5, 51);
        milk.DecreasePrice(discount);

        reporting.RegisterShipment("Milk", 20);
        reporting.RegisterShipment("Sugar", 30);
        reporting.RegisterShipment("Tea", 5);

        Console.WriteLine("\nBalances after shipment:");
        reporting.GenerateInventoryReport();

        Console.WriteLine("\nProducts info:");
        milk.DisplayInfo();
        sugar.DisplayInfo();
        tea.DisplayInfo();
        flour.DisplayInfo();
    }
}