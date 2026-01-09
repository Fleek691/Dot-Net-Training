// public delegate string PrintMessage(string message);


// public class PrintingComapny
// {
    
//     public PrintMessage CustomerChoicePrintMessage{get;set;}
//     // public void Print(string message)
//     // {
//     //     string messageToPrint=CustomerChoicePrintMessage(message);
//     //     System.Console.WriteLine(messageToPrint);
//     // }
//     // private static string Method1(string message)
//     // {
//     //     return "Welcom";
//     // }
//     //  public string Simple(string message)
//     // {
//     //     return message;
//     // }

//     // public string NewYear(string message)
//     // {
//     //     return "Happy new year "+ message;
//     // }
//     // public string Diwali(string message)
//     // {
//     //     return "Happy DIwali "+ message;
//     // }
//     public static void MethodsA(string message)=>System.Console.WriteLine("A: "+message);    
//     static void MethodsB(string message)=>System.Console.WriteLine("B: "+message);    
//     static void MethodsC(string message)=>System.Console.WriteLine("C: "+message);    

    


// }
public delegate void PrintMessage(string message);

public class PrintingComapny
{
    public PrintMessage CustomerChoicePrintMessage { get; set; }

    public static void MethodsA(string message) => Console.WriteLine("A: " + message);
    public static void MethodsB(string message) => Console.WriteLine("B: " + message);
    public static void MethodsC(string message) => Console.WriteLine("C: " + message);
}
