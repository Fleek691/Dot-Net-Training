using System;
using System.Numerics;

/// <summary>
/// Class for calculating factorial of large numbers.
/// </summary>
public class FactorialLarge
{
    /// <summary>
    /// Calculates N! and handles potential overflow for larger integers using BigInteger.
    /// </summary>
    /// <param name="n">The number to calculate factorial for.</param>
    /// <returns>The factorial as BigInteger.</returns>
    public static BigInteger CalculateFactorial(int n)
    {
        if (n < 0) throw new ArgumentException("Factorial is not defined for negative numbers.");
        BigInteger result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}