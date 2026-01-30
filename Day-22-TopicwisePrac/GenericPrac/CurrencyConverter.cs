public class Product1
{
    public string? Name { get; set; }
    public decimal BasePrice { get; set; }
}

public class Calculator
{
    public decimal CalculateTotal<T>(T item, int qty, Func<T, int, decimal> priceCalculator)
    {
        return priceCalculator(item, qty);
    }
}

public class Helper2
{
    public static void Main(string[] args)
    {
        var myProduct = new Product1 { Name = "Laptop", BasePrice = 1000m };
        var calculator = new Calculator();

        // Usage: Calculate total with 15% tax
        var total = calculator.CalculateTotal(myProduct, 3, (p, q) => (p.BasePrice * q) * 1.15m);

        System.Console.WriteLine($"Product: {myProduct.Name}");
        System.Console.WriteLine($"Base Price: {myProduct.BasePrice:C}");
        System.Console.WriteLine($"Quantity: 3");
        System.Console.WriteLine($"Total with 15% Tax: {total:C}");
    }
}