using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryStockManagement
{
    public class InventoryManager
    {
        private List<Product> products = new List<Product>();
        private List<StockMovement> stockMovements = new List<StockMovement>();
        private int nextMovementId = 1;

        public void AddProduct(string code, string name, string category, string supplier, double price, int stock, int minLevel)
        {
            var product = new Product
            {
                ProductCode = code,
                ProductName = name,
                Category = category,
                Supplier = supplier,
                UnitPrice = price,
                CurrentStock = stock,
                MinimumStockLevel = minLevel
            };
            products.Add(product);
            Console.WriteLine($"Product '{name}' added with code: {code}");
        }

        public bool UpdateStock(string productCode, string movementType, int quantity, string reason)
        {
            var product = products.FirstOrDefault(p => p.ProductCode == productCode);
            if (product == null)
            {
                Console.WriteLine("Product not found!");
                return false;
            }

            if (movementType == "Out" && product.CurrentStock < quantity)
            {
                Console.WriteLine("Insufficient stock!");
                return false;
            }

            var movement = new StockMovement
            {
                MovementId = nextMovementId++,
                ProductCode = productCode,
                MovementDate = DateTime.Now,
                MovementType = movementType,
                Quantity = quantity,
                Reason = reason
            };
            stockMovements.Add(movement);

            if (movementType == "In")
            {
                product.CurrentStock += quantity;
            }
            else if (movementType == "Out")
            {
                product.CurrentStock -= quantity;
            }

            Console.WriteLine($"Stock updated for {product.ProductName}. New stock: {product.CurrentStock}");
            return true;
        }

        public Dictionary<string, List<Product>> GroupProductsByCategory()
        {
            return products.GroupBy(p => p.Category)
                          .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Product> GetLowStockProducts()
        {
            return products.Where(p => p.CurrentStock <= p.MinimumStockLevel)
                          .ToList();
        }

        public Dictionary<string, int> GetStockValueByCategory()
        {
            return products.GroupBy(p => p.Category)
                          .ToDictionary(g => g.Key, g => (int)g.Sum(p => p.CurrentStock * p.UnitPrice));
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public List<StockMovement> GetAllMovements()
        {
            return stockMovements;
        }
    }
}
