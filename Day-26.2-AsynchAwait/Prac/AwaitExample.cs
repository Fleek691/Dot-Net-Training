using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("A");
        await PrintAfterDelayAsync();
        Console.WriteLine("C");
    }

    static async Task PrintAfterDelayAsync()
    {
        Console.WriteLine("B1");
        await Task.Delay(5000);
        Console.WriteLine("B2");
    }
}

// Expected output order:
// A
// B1
// (pause ~500ms)
// B2
// C