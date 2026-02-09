using System;
using System.Text;
using System.Diagnostics;

public class LogFormatter
{
    public static void Main()
    {
        int n = 10000;

        Stopwatch sw1 = new Stopwatch();
        sw1.Start();

        string logs1 = "";
        for (int i = 0; i < n; i++)
        {
            logs1 += $"Log {i}: System running...\n";
        }

        sw1.Stop();
        Console.WriteLine($"String (+) Time: {sw1.ElapsedMilliseconds} ms");

        Stopwatch sw2 = new Stopwatch();
        sw2.Start();

        StringBuilder logs2 = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            logs2.Append($"Log {i}: System running...\n");
        }

        sw2.Stop();
        Console.WriteLine($"StringBuilder Time: {sw2.ElapsedMilliseconds} ms");
    }
}
