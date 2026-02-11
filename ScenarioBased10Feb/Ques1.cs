using System;
using System.Collections.Generic;
using System.Linq;

// Base product interface
public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Generic Repository
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();

    public void AddProduct(T product)
    {
        if (_products.Any(p => p.Id == product.Id))
        {
            Console.WriteLine("Id must be unique");
            return;
        }

        if (product.Price <= 0)
        {
            Console.WriteLine("Invalid Price");
            return;
        }

        if (string.IsNullOrEmpty(product.Name))
        {
            Console.WriteLine("Name cannot be empty");
            return;
        }

        _products.Add(product);
    }

    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        return _products.Where(predicate);
    }

    public decimal CalculateTotalValue()
    {
        return _products.Sum(e => e.Price);
    }
}

// 2. Electronic Product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string? Brand { get; set; }
}

// 3. Discount Wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 100)
            throw new ArgumentException("Invalid Discount");

        _product = product;
        _discountPercentage = discountPercentage;
    }

    public decimal DiscountedPrice =>
        _product.Price * (1 - _discountPercentage / 100);

    public override string ToString()
    {
        return $"{_product.Name} | Original: {_product.Price} | Discounted: {DiscountedPrice}";
    }
}

// 4. Inventory Manager
public class InventoryManager
{
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        Console.WriteLine("\nAll Products:");
        foreach (var item in products)
        {
            Console.WriteLine($"{item.Name} - {item.Price}");
        }

        // Most expensive
        var mostExp = products.OrderByDescending(e => e.Price).FirstOrDefault();
        if (mostExp != null)
            Console.WriteLine($"\nMost Expensive: {mostExp.Name} - {mostExp.Price}");

        // Group by category
        Console.WriteLine("\nGrouped By Category:");
        var cat = products.GroupBy(e => e.Category);
        foreach (var g in cat)
        {
            Console.WriteLine(g.Key);
            foreach (var p in g)
                Console.WriteLine($"  {p.Name}");
        }

        // Discount Electronics > 500
        foreach (var item in products)
        {
            if (item is ElectronicProduct ep && ep.Price > 500)
            {
                ep.Price -= ep.Price * 0.10m;
            }
        }
    }

    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        foreach (var p in products)
        {
            try
            {
                if (p is ElectronicProduct ep)
                {
                    ep.Price = priceAdjuster((T)(object)ep);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

// Program Entry
public class Program1
{
    public static void Main()
    {
        var repo = new ProductRepository<ElectronicProduct>();

        var p1 = new ElectronicProduct { Id = 1, Name = "Laptop", Price = 1200m, Brand = "Dell" };
        var p2 = new ElectronicProduct { Id = 2, Name = "Phone", Price = 800m, Brand = "Samsung" };
        var p3 = new ElectronicProduct { Id = 3, Name = "Headphones", Price = 150m, Brand = "Sony" };
        var p4 = new ElectronicProduct { Id = 4, Name = "Monitor", Price = 400m, Brand = "Dell" };
        var p5 = new ElectronicProduct { Id = 5, Name = "Tablet", Price = 600m, Brand = "Apple" };

        repo.AddProduct(p1);
        repo.AddProduct(p2);
        repo.AddProduct(p3);
        repo.AddProduct(p4);
        repo.AddProduct(p5);

        Console.WriteLine("\nDell Products:");
        var dellProducts = repo.FindProducts(p => p.Brand == "Dell");
        foreach (var p in dellProducts)
            Console.WriteLine($"{p.Name} - {p.Price}");

        Console.WriteLine("\nTotal Value Before Discount:");
        Console.WriteLine(repo.CalculateTotalValue());

        Console.WriteLine("\nDiscounted Products:");
        foreach (var p in dellProducts)
        {
            var dp = new DiscountedProduct<ElectronicProduct>(p, 10);
            Console.WriteLine(dp);
        }

        var manager = new InventoryManager();

        Console.WriteLine("\nProcessing Collection:");
        manager.ProcessProducts(new List<IProduct> { p1, p2, p3, p4, p5 });

        Console.WriteLine("\nPrices After Discount:");
        foreach (var p in new List<IProduct> { p1, p2, p3, p4, p5 })
            Console.WriteLine($"{p.Name} - {p.Price}");

        Console.WriteLine("\nUpdating Prices (+5%):");
        var list = new List<ElectronicProduct> { p1, p2, p3, p4, p5 };
        manager.UpdatePrices(list, prod => prod.Price * 1.05m);

        foreach (var p in list)
            Console.WriteLine($"{p.Name} -> {p.Price}");
    }
}

