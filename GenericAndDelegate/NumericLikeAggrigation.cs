using System;
using System.Collections.Generic;

public class Program7
{
    public static void Main()
    {
        Console.WriteLine(Sum(new List<int> { 1, 2, 3 }));      // Expected: 6
        Console.WriteLine($"{Sum(new List<double> { 1.5, 2.5 }):F1}");  // Expected: 4.0

        // Console.WriteLine(Sum(new List<string> { "a", "b" })); // ❌ Should not compile (string is not struct)
    }

    // ✅ TODO: Students implement only this function
    public static T Sum<T>(IEnumerable<T> items) where T : struct
    {
        
        dynamic a=0;
        foreach(dynamic item in items)
        {
            a+=item;
        }
        return (T)a;
    }
}