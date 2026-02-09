using System;
using System.Threading.Tasks;

namespace ConsoleAsyncAwaitStepByStep;

public static class Sample05_Exceptions
{
    // Goal:
    // - Show that exceptions from async methods appear on the await line
    // - Use try/catch around await

    public static async Task RunAsync()
    {
        Console.WriteLine("Sample 05: Exception handling with await");
        Console.WriteLine("----------------------------------------");

        try
        {
            Console.WriteLine("Calling DivideAsync(10, 0) ...");
            int result = await DivideAsync(10, 0);
            Console.WriteLine("Result: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught exception ✅");
            Console.WriteLine("Type   : " + ex.GetType().Name);
            Console.WriteLine("Message: " + ex.Message);
        }
    }

    private static async Task<int> DivideAsync(int a, int b)
    {
        await Task.Delay(500);   // pretend slow work
        return a / b;            // throws if b is 0
    }
}
