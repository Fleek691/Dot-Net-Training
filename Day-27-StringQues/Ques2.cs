// Problem Statement

// You are given a string S containing lowercase letters.

// Each letter has a numeric value:

// a = 1
// b = 2
// c = 3
// ...
// z = 26

// Task

// Find a character such that:

// 👉 Sum of numeric values of characters to its left

// 👉 Sum of numeric values of characters to its right

// Print that character.

// Input Format

// Single line → String S

// Output Format

// Print the character that satisfies the condition.

// Constraints
// 1 ≤ S.length ≤ 10^5

// Sample Input
// abec

// Sample Output
// e

// Explanation

// Values:

// a = 1
// b = 2
// e = 5
// c = 3


// For e:
// Left sum = 1 + 2 = 3
// Right sum = 3

// So answer = e.
using System;
namespace SearchingAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine()!;
            int rightSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                rightSum += (int)input[i] - (int)'a' + 1;
            }
            int leftSum = 0;
            char result = '-';
            int currVal = 0;
            for (int i = 0; i < input.Length; i++)
            {
                currVal = (int)input[i] - (int)'a' + 1;
                rightSum -= currVal;
                if (leftSum == rightSum)
                {
                    result = input[i];
                    break;
                }
                leftSum += currVal;
            }
            if (result == '-')
            {
                System.Console.WriteLine("404");
            }
            else
            {
                System.Console.WriteLine(result);
            }
        }
    }
}