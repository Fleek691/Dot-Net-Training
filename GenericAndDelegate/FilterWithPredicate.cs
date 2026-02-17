using System;
using System.Collections.Generic;

public class Program5
{
    public static void Main()
    {
        var nums = new List<int> { 2, 5, 8, 11, 14 };

        var evens = Filter(nums, n => n % 2 == 0);
        Console.WriteLine(string.Join(",", evens));         // Expected: 2,8,14

        var big = Filter(nums, n => n >= 10);
        Console.WriteLine(string.Join(",", big));           // Expected: 11,14
    }

    // ✅ TODO: Students implement only this function
    public static List<T> Filter<T>(List<T> items, Predicate<T> match)
    {
        // List<T> result=new List<T>();
        var re= items.Where(pp=>match(pp)).ToList();
        // foreach(var item in items)
        // {
        //     if (match(item))
        //     {
        //         result.Add(item);
        //     }
        // }
        return re;
    }
}