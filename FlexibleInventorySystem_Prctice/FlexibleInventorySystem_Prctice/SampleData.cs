using FlexibleInventorySystem_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice
{
    // Sample data for testing your implementation
    public static class SampleData
    {
        public static List<Product> GetSampleProducts()
        {
            return new List<Product>
        {
            new ElectronicProduct
            {
                Id = "E001",
                Name = "Laptop",
                Price = 999.99m,
                Quantity = 10,
                Category = "Electronics",
                Brand = "Dell",
                WarrantyMonths = 24,
                Voltage = "110-240V"
            },
            new GroceryProduct
            {
                Id = "G001",
                Name = "Milk",
                Price = 3.49m,
                Quantity = 50,
                Category = "Groceries",
                ExpiryDate = DateTime.Now.AddDays(7),
                IsPerishable = true,
                Weight = 1.0
            },
            new ClothingProduct
            {
                Id = "C001",
                Name = "T-Shirt",
                Price = 19.99m,
                Quantity = 100,
                Category = "Clothing",
                Size = "L",
                Color = "Blue",
                Material = "Cotton"
            }
        };
        }
    }
}
