public class EventExample
{
    public delegate void Notify();
    public static event Notify Reached500;

    public static void Main()
    {
        Reached500+=ValueReached500Plus;

        while (true)
        {
            System.Console.WriteLine("Enter a value or 'exit' to quit");
        string? input=Console.ReadLine();
        if (input.ToLower()=="exit")
        {
            break;
            }
            else
            {
                int n=int.Parse(input);
                try
                {
                    if (n > 500)
                    {
                        Reached500();
                    }
                    n=0;
                }
                catch(FormatException)
                {
                    System.Console.WriteLine("Invalid input.");
                }
            }
        }
        
    }

    private static void ValueReached500Plus()
    {
        System.Console.WriteLine("Reached 500");
    }
}