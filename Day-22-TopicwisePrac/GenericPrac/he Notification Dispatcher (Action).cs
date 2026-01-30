public class NotificationSystem
{
    public void ProcessTask<T>(T item, Action<T> action)
    {
        Console.WriteLine("Initializing process...");
        action(item);
        Console.WriteLine("Process complete.");
    }
}

// Usage
public class Dispatcher
{
    public static void Main(string[] args)
    {
        var system = new NotificationSystem();
        system.ProcessTask("Order #1234", msg => Console.WriteLine($"Sending Email: {msg}"));
        system.ProcessTask(500.50m, price => Console.WriteLine($"Logging Transaction: ${price}"));
    }
    
}