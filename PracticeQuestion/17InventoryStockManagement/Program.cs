using System;
using System.Linq;

namespace InventoryStockManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager manager = new InventoryManager();

            Console.WriteLine("=== Inventory Stock Management System ===\n");

            // Test Case 1: Add products with stock levels
            Console.WriteLine("--- Adding Products ---");
            manager.AddProduct("ELEC001", "Laptop Dell XPS", "Electronics", "Dell Inc.", 1200.00, 50, 10);
            manager.AddProduct("ELEC002", "iPhone 15", "Electronics", "Apple Inc.", 999.00, 8, 15);
            manager.AddProduct("FURN001", "Office Chair", "Furniture", "IKEA", 199.99, 30, 5);
            manager.AddProduct("FURN002", "Standing Desk", "Furniture", "ErgoDesk", 450.00, 3, 5);
            manager.AddProduct("BOOK001", "C# Programming Guide", "Books", "Microsoft Press", 49.99, 100, 20);
            manager.AddProduct("BOOK002", "Design Patterns", "Books", "Pearson", 59.99, 25, 10);
            Console.WriteLine();

            // Test Case 2: Update stock (in/out movements)
            Console.WriteLine("--- Processing Stock Movements ---");
            manager.UpdateStock("ELEC001", "Out", 5, "Sale");
            manager.UpdateStock("ELEC002", "Out", 3, "Sale");
            manager.UpdateStock("FURN001", "In", 20, "Purchase");
            manager.UpdateStock("FURN002", "Out", 2, "Sale");
            manager.UpdateStock("BOOK001", "Out", 15, "Sale");
            manager.UpdateStock("ELEC002", "In", 20, "Purchase");
            Console.WriteLine();

            // Test Case 3: Group products by category
            Console.WriteLine("--- Grouping Products by Category ---");
            var groupedProducts = manager.GroupProductsByCategory();
            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"\nCategory: {group.Key}");
                foreach (var product in group.Value)
                {
                    Console.WriteLine($"  - {product.ProductName} ({product.ProductCode}): Stock={product.CurrentStock}, Price=${product.UnitPrice}");
                }
            }
            Console.WriteLine();

            // Test Case 4: Identify low-stock items
            Console.WriteLine("--- Low Stock Alert ---");
            var lowStockProducts = manager.GetLowStockProducts();
            if (lowStockProducts.Count > 0)
            {
                Console.WriteLine($"Found {lowStockProducts.Count} product(s) with low stock:");
                foreach (var product in lowStockProducts)
                {
                    Console.WriteLine($"  - {product.ProductName} ({product.ProductCode}): Current Stock={product.CurrentStock}, Minimum Level={product.MinimumStockLevel}");
                }
            }
            else
            {
                Console.WriteLine("All products have sufficient stock.");
            }
            Console.WriteLine();

            // Test Case 5: Calculate inventory value
            Console.WriteLine("--- Inventory Value by Category ---");
            var stockValueByCategory = manager.GetStockValueByCategory();
            double totalValue = 0;
            foreach (var category in stockValueByCategory)
            {
                Console.WriteLine($"{category.Key}: ${category.Value:N2}");
                totalValue += category.Value;
            }
            Console.WriteLine($"\nTotal Inventory Value: ${totalValue:N2}");

            Console.WriteLine("\n=== End of Inventory Stock Management Demo ===");
        }
    }
}
