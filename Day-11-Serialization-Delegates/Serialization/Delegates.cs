// public delegate string PrintMessage(string message);


// public class PrintingComapny
// {

//     public PrintMessage CustomerChoicePrintMessage{get;set;}
//     public void Print(string message)
//     {
//         string messageToPrint=CustomerChoicePrintMessage(message);
//         System.Console.WriteLine(messageToPrint);
//     }
//     private static string Method1(string message)
//     {
//         return "Welcom";
//     }
//      public string Simple(string message)
//     {
//         return message;
//     }

//     public string NewYear(string message)
//     {
//         return "Happy new year "+ message;
//     }
//     public string Diwali(string message)
//     {
//         return "Happy DIwali "+ message;
//     }
//     public static void MethodsA(string message)=>System.Console.WriteLine("A: "+message);    
//     static void MethodsB(string message)=>System.Console.WriteLine("B: "+message);    
//     static void MethodsC(string message)=>System.Console.WriteLine("C: "+message);    




// }
// public delegate void PrintMessage(string message);

// public class PrintingComapny
// {
//     public PrintMessage CustomerChoicePrintMessage { get; set; }

//     public static void MethodsA(string message) => Console.WriteLine("A: " + message);
//     public static void MethodsB(string message) => Console.WriteLine("B: " + message);
//     public static void MethodsC(string message) => Console.WriteLine("C: " + message);
// }


using System.Net.Mail;

// Delegate declaration
public delegate void Notifier(string message);

// Publisher class that raises the event
public class NotificationService
{
    // Event declaration using the Notifier delegate
    public event Notifier OnNotify;

    // Method to raise the event
    public void SendNotification(string message)
    {
        Console.WriteLine($"Sending notification: {message}");

        // Raise the event if there are subscribers
        OnNotify?.Invoke(message);
    }
}

public class Program
{
    public static void Main()
    {
        // Create an instance of the publisher
        NotificationService service = new NotificationService();

        // Subscribe to the event
        service.OnNotify += SM;
        service.OnNotify += EmailNotification;
        service.OnNotify += SmsNotification;

        // Raise the event
        service.SendNotification("Hello Avishek!");

        Console.WriteLine("\n--- Unsubscribing SMS ---\n");

        // Unsubscribe from event
        service.OnNotify -= SmsNotification;

        service.SendNotification("Second notification");
    }

    public static void SM(string message)
    {
        Console.WriteLine($"Console Notification: {message}");
    }

    public static void EmailNotification(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }

    public static void SmsNotification(string message)
    {
        Console.WriteLine($"SMS sent: {message}");
    }
}