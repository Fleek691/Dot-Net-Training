using System;
using FlexibleInventorySystem_Practice.Services;
using FlexibleInventorySystem_Practice.Models;

namespace FlexibleInventorySystem_Practice
{
    class Program
    {
        private static InventoryManager _inventory = new InventoryManager();

        /*
        static void Main(string[] args)
        {
            // ✅ Seed sample data
            SeedSampleData();

            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1": AddProductMenu(); break;
                    case "2": RemoveProductMenu(); break;
                    case "3": UpdateQuantityMenu(); break;
                    case "4": FindProductMenu(); break;
                    case "5": ViewAllProducts(); break;
                    case "6": GenerateReportsMenu(); break;
                    case "7": LowStockMenu(); break;
                    case "8": return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        */

        // ✅ Add Sample Data Automatically
        static void SeedSampleData()
        {
            var sampleProducts = SampleData.GetSampleProducts();

            foreach (var product in sampleProducts)
            {
                product.DateAdded = DateTime.Now; // ensure required property
                _inventory.AddProduct(product);
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("===== INVENTORY MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Update Quantity");
            Console.WriteLine("4. Find Product");
            Console.WriteLine("5. View All Products");
            Console.WriteLine("6. Generate Reports");
            Console.WriteLine("7. Check Low Stock");
            Console.WriteLine("8. Exit");
            Console.Write("Select option: ");
        }

        static void RemoveProductMenu()
        {
            Console.Write("Enter Product ID: ");
            string id = Console.ReadLine()!;

            if (_inventory.RemoveProduct(id))
                Console.WriteLine("Product removed.");
            else
                Console.WriteLine("Product not found.");
        }

        static void UpdateQuantityMenu()
        {
            Console.Write("Enter Product ID: ");
            string id = Console.ReadLine()!;

            Console.Write("New Quantity: ");
            int qty = int.Parse(Console.ReadLine()!);

            if (_inventory.UpdateQuantity(id, qty))
                Console.WriteLine("Quantity updated.");
            else
                Console.WriteLine("Product not found.");
        }

        static void FindProductMenu()
        {
            Console.Write("Enter Product ID: ");
            string id = Console.ReadLine()!;

            var product = _inventory.FindProduct(id);

            if (product != null)
                Console.WriteLine(product.GetProductDetails());
            else
                Console.WriteLine("Product not found.");
        }

        static void ViewAllProducts()
        {
            Console.WriteLine(_inventory.GenerateInventoryReport());
        }

        static void GenerateReportsMenu()
        {
            Console.WriteLine("1. Value Report");
            Console.WriteLine("2. Expiry Report");

            string choice = Console.ReadLine()!;

            if (choice == "1")
            {
                Console.WriteLine(_inventory.GenerateValueReport());
            }
            else if (choice == "2")
            {
                Console.Write("Enter days threshold: ");
                int days = int.Parse(Console.ReadLine()!);
                Console.WriteLine(_inventory.GenerateExpiryReport(days));
            }
        }

        static void LowStockMenu()
        {
            Console.Write("Enter stock threshold: ");
            int threshold = int.Parse(Console.ReadLine()!);

            var products = _inventory.GetLowStockProducts(threshold);

            foreach (var product in products)
            {
                Console.WriteLine(product.GetProductDetails());
            }
        }

        // You can implement AddProductMenu later if needed
        static void AddProductMenu()
        {
            Console.WriteLine("Manual product addition not implemented in this version.");
        }
    }
}
