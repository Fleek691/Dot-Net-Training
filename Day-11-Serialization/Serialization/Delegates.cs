public delegate string PrintMessage(string message);

public class PrintingComapny
{
    
    public PrintMessage CustomerChoicePrintMessage{get;set;}
    public void Print(string message)
    {
        string messageToPrint=CustomerChoicePrintMessage(message);
        System.Console.WriteLine(messageToPrint);
    }
    private static string Method1(string message)
    {
        return "Welcom";
    }
     public string Simple(string message)
    {
        return message;
    }

    public string NewYear(string message)
    {
        return "Happy new year "+ message;
    }
    public string Diwali(string message)
    {
        return "Happy DIwali "+ message;
    }
    

    


}