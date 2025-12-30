using System;

/// <summary>
/// Class for calculating sum of digits and digital root.
/// </summary>
public class SumOfDigits
{
    /// <summary>
    /// Repeatedly sums the digits of a number until the result is a single digit (Digital Root).
    /// </summary>
    /// <param name="number">The number to process.</param>
    /// <returns>The digital root.</returns>
    public static int DigitalRoot(int number)
    {
        while (number >= 10)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            number = sum;
        }
        return number;
    }
}