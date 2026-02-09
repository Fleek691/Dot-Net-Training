using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleAsyncAwaitStepByStep;

public static class Sample04_WhenAll
{
    // Goal:
    // - Start multiple tasks first
    // - Await all of them using Task.WhenAll

    public static async Task RunAsync()
    {
        Console.WriteLine("Sample 04: Task.WhenAll (run tasks together)");
        Console.WriteLine("--------------------------------------------");

        var sw = Stopwatch.StartNew();

        Task<string> t1 = FakeDownloadAsync("File-A", 900);
        Task<string> t2 = FakeDownloadAsync("File-B", 450);
        Task<string> t3 = FakeDownloadAsync("File-C", 700);

        Console.WriteLine("All tasks started. Waiting for all to finish...");

        string[] results = await Task.WhenAll(t1, t2, t3);

        sw.Stop();
        Console.WriteLine();
        Console.WriteLine("Results:");
        foreach (var r in results)
            Console.WriteLine("  " + r);

        Console.WriteLine();
        Console.WriteLine("Total time (ms): " + sw.ElapsedMilliseconds);
        Console.WriteLine("(Notice: total time is close to the longest single task, not the sum.)");
    }

    private static async Task<string> FakeDownloadAsync(string name, int delayMs)
    {
        Console.WriteLine($"{name}: started ({delayMs}ms)");
        await Task.Delay(delayMs);
        Console.WriteLine($"{name}: finished");
        return $"{name}: OK";
    }
}
