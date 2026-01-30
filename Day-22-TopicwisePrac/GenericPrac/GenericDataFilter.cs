public class Product
{
    public string? Name { get; set; }
    public double Price { get; set; }

    public override string ToString()
    {
        return $"Product: {Name}, Price: {Price}";
    }
}

public class Filter
{
    public static List<T> FilterData<T>(List<T> items, Predicate<T> condition)
    {
        List<T> result = new List<T>();
        foreach (var item in items)
        {
            if (condition(item))
                result.Add(item);
        }
        return result;
    }
}

public class Helper
{
    public static void Main(string[] args)
    {
        // Create a list of products
        List<Product> productList = new List<Product>
        {
            new Product { Name = "Laptop", Price = 1200 },
            new Product { Name = "Mouse", Price = 25 },
            new Product { Name = "Keyboard", Price = 75 },
            new Product { Name = "Monitor", Price = 1500 },
            new Product { Name = "USB Cable", Price = 10 }
        };

        // Usage: Filtering high-value products
        var expensiveProducts = Filter.FilterData(productList, p => p.Price > 1000);

        System.Console.WriteLine("Products with price > 1000:");
        foreach (var item in expensiveProducts)
        {
            System.Console.WriteLine(item);
        }
    }
}