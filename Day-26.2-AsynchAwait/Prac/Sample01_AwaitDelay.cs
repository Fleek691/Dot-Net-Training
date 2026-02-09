using System;
using System.Threading.Tasks;

namespace ConsoleAsyncAwaitStepByStep;

public static class Sample01_AwaitDelay
{
    // Goal:
    // - Show the simplest async method: await Task.Delay(...)
    // - Show that code continues AFTER the delay

    public static async Task RunAsync()
    {
        Console.WriteLine("Sample 01: await Task.Delay (basic async wait)");
        Console.WriteLine("---------------------------------------------");

        Console.WriteLine($"1) Start time : {DateTime.Now:HH:mm:ss.fff}");
        Console.WriteLine("2) Waiting 2 seconds using await Task.Delay(2000) ...");

        // ✅ This does NOT block the thread like Thread.Sleep.
        // It waits asynchronously and then continues later.
        await Task.Delay(2000);

        Console.WriteLine($"3) End time   : {DateTime.Now:HH:mm:ss.fff}");
        Console.WriteLine("4) Code continued after await ✅");
    }
}
