using System;

/// <summary>
/// Class for printing Pascal's triangle.
/// </summary>
public class PascalsTriangle
{
    /// <summary>
    /// Prints Pascal's triangle up to N rows using nested loops.
    /// </summary>
    /// <param name="n">Number of rows.</param>
    public static void PrintPascalsTriangle(int n)
    {
        for (int i = 0; i < n; i++)
        {
            // Print spaces for alignment
            for (int j = 0; j < n - i - 1; j++)
            {
                Console.Write(" ");
            }
            int value = 1;
            for (int j = 0; j <= i; j++)
            {
                Console.Write(value + " ");
                value = value * (i - j) / (j + 1);
            }
            Console.WriteLine();
        }
    }
}