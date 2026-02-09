using System;
using System.Threading.Tasks;

namespace ConsoleAsyncAwaitStepByStep;

public static class Sample02_TaskOfT
{
    // Goal:
    // - Show Task<T> returning a value later

    public static async Task RunAsync()
    {
        Console.WriteLine("Sample 02: Task<T> return value");
        Console.WriteLine("-------------------------------");

        Console.WriteLine("Calling GetNumberAsync() ...");
        int result = await GetNumberAsync();

        Console.WriteLine("Returned value = " + result);
    }

    // Task<int> means: "I will give you an int later"
    private static async Task<int> GetNumberAsync()
    {
        Console.WriteLine("Inside GetNumberAsync: doing work for 1 second...");
        await Task.Delay(1000);
        return 99;
    }
}
