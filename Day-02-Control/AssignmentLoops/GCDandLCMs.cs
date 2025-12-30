using System;

/// <summary>
/// Class for calculating GCD and LCM.
/// </summary>
public class GCDandLCM
{
    /// <summary>
    /// Finds the Greatest Common Divisor of two numbers using Euclidean algorithm.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    /// <returns>The GCD.</returns>
    public static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    /// <summary>
    /// Finds the Least Common Multiple of two numbers.
    /// </summary>
    /// <param name="a">First number.</param>
    /// <param name="b">Second number.</param>
    /// <returns>The LCM.</returns>
    public static int LCM(int a, int b)
    {
        return (a / GCD(a, b)) * b; // To avoid overflow
    }
}