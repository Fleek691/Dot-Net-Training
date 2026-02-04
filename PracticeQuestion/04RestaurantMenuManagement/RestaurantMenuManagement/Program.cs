using System;
using System.Collections.Generic;

class Program2
{
    static void Main()
    {
        MenuManager manager = new MenuManager();

        // ===== TEST CASE 1: Add menu items =====
        manager.AddMenuItem("Spring Rolls", "Appetizer", 120, true);
        manager.AddMenuItem("Chicken Biryani", "Main Course", 250, false);
        manager.AddMenuItem("Paneer Butter Masala", "Main Course", 220, true);
        manager.AddMenuItem("Ice Cream", "Dessert", 90, true);
        manager.AddMenuItem("Brownie", "Dessert", 110, true);

        Console.WriteLine("Menu items added successfully.\n");

        // ===== TEST CASE 2: Group items by category =====
        Console.WriteLine("Menu Grouped By Category:");
        var groupedMenu = manager.GroupItemsByCategory();

        foreach (var category in groupedMenu)
        {
            Console.WriteLine($"\nCategory: {category.Key}");
            foreach (var item in category.Value)
            {
                Console.WriteLine(
                    $"  {item.ItemName} - ₹{item.Price} {(item.IsVegetarian ? "(Veg)" : "(Non-Veg)")}"
                );
            }
        }

        // ===== TEST CASE 3: Get vegetarian items =====
        Console.WriteLine("\nVegetarian Menu Items:");
        var vegItems = manager.GetVegetarianItems();

        foreach (var item in vegItems)
        {
            Console.WriteLine($"{item.ItemName} - ₹{item.Price}");
        }

        // ===== TEST CASE 4: Average price by category =====
        Console.WriteLine("\nAverage Prices:");
        Console.WriteLine(
            "Appetizer Avg Price: ₹" +
            manager.CalculateAveragePriceByCategory("Appetizer")
        );
        Console.WriteLine(
            "Main Course Avg Price: ₹" +
            manager.CalculateAveragePriceByCategory("Main Course")
        );
        Console.WriteLine(
            "Dessert Avg Price: ₹" +
            manager.CalculateAveragePriceByCategory("Dessert")
        );

        Console.ReadLine();
    }
}
