using System;
using System.Threading.Tasks;

namespace ConsoleAsyncAwaitStepByStep;

public class Program
{
    public static async Task Main()
    {
        Console.Title = "C# Async/Await - Step-by-step Console Samples";

        while (true)
        {
            Console.Clear();
            Console.WriteLine("C# Async/Await - Step-by-step Console Samples");
            Console.WriteLine("===========================================");
            Console.WriteLine("Pick a sample to run:");
            Console.WriteLine("  1) await Task.Delay (basic async wait)");
            Console.WriteLine("  2) Task<T> return value");
            Console.WriteLine("  3) Async method chain (A awaits B)");
            Console.WriteLine("  4) Task.WhenAll (run tasks together)");
            Console.WriteLine("  5) Exception handling with await");
            Console.WriteLine("  6) CancellationToken (cancel async work)");
            Console.WriteLine("  0) Exit");
            Console.WriteLine();
            Console.Write("Enter choice: ");

            string? choice = Console.ReadLine();

            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    await Sample01_AwaitDelay.RunAsync();
                    break;
                case "2":
                    await Sample02_TaskOfT.RunAsync();
                    break;
                case "3":
                    await Sample03_MethodChain.RunAsync();
                    break;
                case "4":
                    await Sample04_WhenAll.RunAsync();
                    break;
                case "5":
                    await Sample05_Exceptions.RunAsync();
                    break;
                case "6":
                    await Sample06_Cancellation.RunAsync();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again...");
                    Console.ReadLine();
                    continue;
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to return to menu...");
            Console.ReadLine();
        }
    }
}
