using System;

/// <summary>
/// Class demonstrating the use of continue statement.
/// </summary>
public class ContinueUsage
{
    /// <summary>
    /// Prints numbers from 1 to 50, but skips all multiples of 3 using continue.
    /// </summary>
    public static void PrintNumbersSkippingMultiplesOf3()
    {
        for (int i = 1; i <= 50; i++)
        {
            if (i % 3 == 0)
            {
                continue;
            }
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}