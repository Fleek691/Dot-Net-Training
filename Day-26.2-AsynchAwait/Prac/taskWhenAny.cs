using System;
using System.Threading.Tasks;

class Program2
{
    static async Task Main()
    {
        Task<string> slow = GetValueAsync("slow", 9000);
        Task<string> fast = GetValueAsync("fast", 3000);

        Task<string> first = await Task.WhenAny(slow, fast);
        Console.WriteLine("First finished: " + await first);
    }

    static async Task<string> GetValueAsync(string name, int delayMs)
    {
        await Task.Delay(delayMs);
        return name;
    }
}