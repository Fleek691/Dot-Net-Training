using System;

/// <summary>
/// Class for printing diamond patterns.
/// </summary>
public class DiamondPattern
{
    /// <summary>
    /// Prints a diamond shape using * characters with nested loops.
    /// </summary>
    /// <param name="n">The number of rows for the upper half (total rows = 2*n - 1).</param>
    public static void PrintDiamond(int n)
    {
        // Upper half
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n - i; j++)
            {
                Console.Write(" ");
            }
            for (int j = 1; j <= 2 * i - 1; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        // Lower half
        for (int i = n - 1; i >= 1; i--)
        {
            for (int j = 1; j <= n - i; j++)
            {
                Console.Write(" ");
            }
            for (int j = 1; j <= 2 * i - 1; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}