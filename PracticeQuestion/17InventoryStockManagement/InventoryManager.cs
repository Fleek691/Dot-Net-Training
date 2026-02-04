using System.Collections.Generic;

namespace InventoryStockManagement
{
    public class InventoryManager
    {
        public void AddProduct(string code, string name, string category, string supplier, double price, int stock, int minLevel)
        {
        }

        public bool UpdateStock(string productCode, string movementType, int quantity, string reason)
        {
            return false;
        }

        public Dictionary<string, List<Product>> GroupProductsByCategory()
        {
            return null;
        }

        public List<Product> GetLowStockProducts()
        {
            return null;
        }

        public Dictionary<string, int> GetStockValueByCategory()
        {
            return null;
        }
    }
}
