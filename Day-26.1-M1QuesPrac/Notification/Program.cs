public interface INotifier
{
    public void Send(string Message);
}
public class Email : INotifier
{
    public void Send(string Message)
    {
        System.Console.WriteLine($"Email Notification :{Message}");
    }
}
public class WhatsApp : INotifier
{
    public void Send(string Message)
    {
        System.Console.WriteLine($"WhatsApp Notification :{Message}");
    }
}
public class Sms : INotifier
{
    public void Send(string Message)
    {
        System.Console.WriteLine($"Sms Notification :{Message}");
    }
}
public class Helper
{
    public static void Main()
    {
        List<INotifier> notification=new List<INotifier>();
        WhatsApp wp=new WhatsApp();
        Email em=new();
        Sms sms=new();
        notification.Add(wp);
        notification.Add(em);
        notification.Add(sms);
        System.Console.Write("Enter Message: ");
        string Message=Console.ReadLine()!;
        foreach (var item in notification)
        {
            item.Send(Message);
        }
    }
}