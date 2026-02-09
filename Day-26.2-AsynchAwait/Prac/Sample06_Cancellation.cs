using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAsyncAwaitStepByStep;

public static class Sample06_Cancellation
{
    // Goal:
    // - Cancel an async operation using CancellationTokenSource + CancellationToken
    // - Show OperationCanceledException

    public static async Task RunAsync()
    {
        Console.WriteLine("Sample 06: CancellationToken (cancel async work)");
        Console.WriteLine("-----------------------------------------------");

        using var cts = new CancellationTokenSource();

        Console.WriteLine("This demo will auto-cancel after 2 seconds.");
        cts.CancelAfter(2000);

        try
        {
            await LongWorkAsync(cts.Token);
            Console.WriteLine("Completed ✅");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Cancelled ❌ (OperationCanceledException)");
        }
    }

    private static async Task LongWorkAsync(CancellationToken token)
    {
        for (int i = 1; i <= 10; i++)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"Working... step {i}/10");
            await Task.Delay(400, token); // delay that can be cancelled
        }
    }
}
