using System;

/// <summary>
/// Class for checking strong numbers.
/// </summary>
public class StrongNumber
{
    /// <summary>
    /// Calculates the factorial of a digit.
    /// </summary>
    /// <param name="n">The digit.</param>
    /// <returns>The factorial.</returns>
    private static int Factorial(int n)
    {
        int fact = 1;
        for (int i = 2; i <= n; i++)
        {
            fact *= i;
        }
        return fact;
    }

    /// <summary>
    /// Checks if the sum of the factorial of digits is equal to the number itself.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if strong number, false otherwise.</returns>
    public static bool IsStrongNumber(int number)
    {
        int original = number;
        int sum = 0;
        while (number > 0)
        {
            int digit = number % 10;
            sum += Factorial(digit);
            number /= 10;
        }
        return sum == original;
    }
}