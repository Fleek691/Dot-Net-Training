using System;
using System.Threading.Tasks;

namespace ConsoleAsyncAwaitStepByStep;

public static class Sample03_MethodChain
{
    // Goal:
    // - Show "async all the way"
    // - AAsync awaits BAsync

    public static async Task RunAsync()
    {
        Console.WriteLine("Sample 03: Async method chain (A awaits B)");
        Console.WriteLine("------------------------------------------");

        Console.WriteLine("Main: calling AAsync()");
        await AAsync();
        Console.WriteLine("Main: AAsync finished ✅");
    }

    private static async Task AAsync()
    {
        Console.WriteLine("AAsync: started");
        await BAsync();
        Console.WriteLine("AAsync: finished");
    }

    private static async Task BAsync()
    {
        Console.WriteLine("BAsync: started");
        await Task.Delay(1200);
        Console.WriteLine("BAsync: finished after await");
    }
}
