using System;
using System.Collections.Generic;

class Program3Product
{
    static void Main()
    {
        InventoryManager manager = new InventoryManager();

        // ===== TEST CASE 1: Add products =====
        manager.AddProduct("Laptop", "Electronics", 65000, 10);
        manager.AddProduct("Headphones", "Electronics", 2500, 30);
        manager.AddProduct("T-Shirt", "Clothing", 799, 50);
        manager.AddProduct("Jeans", "Clothing", 1999, 25);
        manager.AddProduct("Book - C# Basics", "Books", 499, 100);

        Console.WriteLine("Products added successfully.\n");

        // ===== TEST CASE 2: Display products grouped by category =====
        Console.WriteLine("Products Grouped By Category:");
        var groupedProducts = manager.GroupProductsByCategory();

        foreach (var category in groupedProducts)
        {
            Console.WriteLine($"\nCategory: {category.Key}");
            foreach (var product in category.Value)
            {
                Console.WriteLine(
                    $"{product.ProductCode} - {product.ProductName} - ₹{product.Price} - Stock: {product.StockQuantity}"
                );
            }
        }

        // ===== TEST CASE 3: Update stock after sale =====
        Console.WriteLine("\nUpdating stock (selling 3 units of P001)...");
        bool updated = manager.UpdateStock("P001", 3);

        Console.WriteLine(updated
            ? "Stock updated successfully."
            : "Stock update failed.");

        // ===== TEST CASE 4: Get products below a price =====
        Console.WriteLine("\nProducts below ₹2000:");
        var cheapProducts = manager.GetProductsBelowPrice(2000);

        foreach (var product in cheapProducts)
        {
            Console.WriteLine(
                $"{product.ProductCode} - {product.ProductName} - ₹{product.Price}"
            );
        }

        // ===== TEST CASE 5: Category-wise stock summary =====
        Console.WriteLine("\nCategory-wise Stock Summary:");
        var stockSummary = manager.GetCategoryStockSummary();

        foreach (var entry in stockSummary)
        {
            Console.WriteLine($"{entry.Key} : {entry.Value} items");
        }

        Console.ReadLine();
    }
}
