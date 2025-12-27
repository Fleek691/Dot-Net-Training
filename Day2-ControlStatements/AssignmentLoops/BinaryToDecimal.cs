using System;

/// <summary>
/// Class for converting binary to decimal.
/// </summary>
public class BinaryToDecimal
{
    /// <summary>
    /// Converts a binary number string to decimal without using built-in library functions.
    /// </summary>
    /// <param name="binary">The binary string (e.g., "101").</param>
    /// <returns>The decimal equivalent.</returns>
    /// <exception cref="ArgumentException">Thrown if the string contains invalid characters.</exception>
    public static int ConvertToDecimal(string binary)
    {
        int decimalValue = 0;
        int power = 0;
        for (int i = binary.Length - 1; i >= 0; i--)
        {
            char c = binary[i];
            if (c == '1')
            {
                decimalValue += (1 << power); // 1 << power is 2^power
            }
            else if (c != '0')
            {
                throw new ArgumentException("Invalid binary digit.");
            }
            power++;
        }
        return decimalValue;
    }
}