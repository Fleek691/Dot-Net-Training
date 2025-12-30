using System;

/// <summary>
/// Class for reversing integers and checking palindromes.
/// </summary>
public class ReversePalindrome
{
    /// <summary>
    /// Reverses an integer using a while loop.
    /// </summary>
    /// <param name="number">The number to reverse.</param>
    /// <returns>The reversed number.</returns>
    public static int Reverse(int number)
    {
        int reversed = 0;
        while (number != 0)
        {
            int digit = number % 10;
            reversed = reversed * 10 + digit;
            number /= 10;
        }
        return reversed;
    }

    /// <summary>
    /// Checks if a number is a palindrome by comparing it to its reverse.
    /// </summary>
    /// <param name="number">The number to check.</param>
    /// <returns>True if palindrome, false otherwise.</returns>
    public static bool IsPalindrome(int number)
    {
        return number == Reverse(number);
    }
}