using FlexibleInventorySystem_Practice.Interfaces;
using FlexibleInventorySystem_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Services
{
    public class InventoryManager : IInventoryOperations, IReportGenerator
    {
        private readonly List<Product> _products;
        private readonly object _lockObject = new object();

        public InventoryManager()
        {
            _products = new List<Product>();
        }

        public bool AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            if (_products.Any(e => e.Id == product.Id))
            {
                return false;
            }
            _products.Add(product);
            return true;
        }

        public Product FindProduct(string productId)
        {
            return _products.FirstOrDefault(e => e.Id == productId)!;
        }

        public string GenerateCategorySummary()
        {
            string result = string.Join(" ", _products.Select(w => w.Category).Distinct());
            return result;
        }

        public string GenerateExpiryReport(int daysThreshold)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in _products)
            {
                if (item is GroceryProduct gp)
                {
                    int daysleft = gp.DaysUntilExpiry();
                    if (daysleft >= 0 && daysleft <= daysThreshold)
                    {
                        result.AppendLine($"Item:{gp.Name} is about to expire in {daysleft} days");
                    }
                }
            }
            return result.ToString();

        }

        public string GenerateInventoryReport()
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in _products)
            {
                result.AppendLine($"{item.GetProductDetails()}");
            }
            return result.ToString();
        }

        public string GenerateValueReport()
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in _products)
            {
                result.AppendLine($"{item.GetProductDetails()} = {item.CalculateValue()}");
            }
            return result.ToString();
        }

        public List<Product> GetLowStockProducts(int threshold)
        {
            List<Product> lowStock = new List<Product>();
            foreach (var item in _products)
            {
                if (item.Quantity <= threshold)
                {
                    lowStock.Add(item);
                }
            }
            return lowStock;
        }

        public List<Product> GetProductsByCategory(string category)
        {
            var cat = _products.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            return cat;
        }

        public decimal GetTotalInventoryValue()
        {
            var total = _products.Sum(e => e.CalculateValue());
            return total;
        }

        public bool RemoveProduct(string productId)
        {
            var a = _products.FirstOrDefault(e => e.Id == productId);
            if (a == null)
            {
                return false;
            }
            _products.Remove(a);
            return true;
        }

        // Implement all interface methods here

        // Additional methods for bonus features
        public IEnumerable<Product> SearchProducts(Func<Product, bool> predicate)
        {
            return _products.Where(predicate);
        }

        public bool UpdateQuantity(string productId, int newQuantity)
        {

            foreach (var item in _products)
            {
                if (item.Id == productId)
                {
                    item.Quantity = newQuantity;
                    return true;
                }
            }
            return false;
        }


    }
}
