using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryManager
{
    // ProductCode → Product
    private Dictionary<string, Product> productCatalog =
        new Dictionary<string, Product>();

    // Counter for ProductCode generation
    private int nextCode = 1;

    // Adds product with auto-generated ProductCode (P001, P002...)
    public void AddProduct(string name, string category, double price, int stock)
    {
        if (price <= 0 || stock < 0)
        {
            Console.WriteLine("Invalid product details.");
            return;
        }

        string productCode = $"P{nextCode:D3}";//P101,P002

        productCatalog.Add(
            productCode,
            new Product(productCode, name, category, price, stock)
        );

        nextCode++;
    }

    // Groups products by category
    public SortedDictionary<string, List<Product>> GroupProductsByCategory()
    {
        var result = productCatalog.Values
            .GroupBy(p => p.Category)
            .ToDictionary(g => g.Key, g => g.ToList());

        return new SortedDictionary<string, List<Product>>(result);
    }

    // Updates stock AFTER sales (reduces quantity)
    // Returns false if product not found or insufficient stock
    public bool UpdateStock(string productCode, int quantity)
    {
        if (!productCatalog.ContainsKey(productCode) || quantity <= 0)
            return false;

        var product = productCatalog[productCode];

        if (product.StockQuantity < quantity)
            return false;

        product.StockQuantity -= quantity;
        return true;
    }

    // Returns products below specified price
    public List<Product> GetProductsBelowPrice(double maxPrice)
    {
        return productCatalog.Values
            .Where(p => p.Price <= maxPrice)
            .ToList();
    }

    // Returns total stock quantity per category
    public Dictionary<string, int> GetCategoryStockSummary()
    {
        return productCatalog.Values
            .GroupBy(p => p.Category)
            .ToDictionary(
                g => g.Key,
                g => g.Sum(p => p.StockQuantity)
            );
    }
}
