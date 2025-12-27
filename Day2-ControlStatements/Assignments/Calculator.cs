using System;
using System.Transactions;

public class Calculator
{
    public static void Operations()
    {
        Console.Write("Enter first digit: ");
        long firstDigit=Convert.ToInt64(Console.ReadLine());

        Console.Write("Enter the second digit: ");
        long secondDigit=Convert.ToInt64(Console.ReadLine());

        Console.Write("Enter the operation you want to perform: ");
        string? s=Console.ReadLine();
        if (string.IsNullOrEmpty(s))
        {
            System.Console.WriteLine("Enter a Valid Operation");
        }
        char op=Convert.ToChar(s);

        switch (op)
        {
            case '+':
                Console.WriteLine($"The addition of {firstDigit} and {secondDigit} is {firstDigit+secondDigit}");
                break;
            case '-':
                Console.WriteLine($"The subtraction of {firstDigit} and {secondDigit} is {firstDigit-secondDigit}");
                break;
            case '*':
                Console.WriteLine($"The multiplication of {firstDigit} and {secondDigit} is {firstDigit*secondDigit}");
                break;
            case '/':
                Console.WriteLine($"The division of {firstDigit} and {secondDigit} is {firstDigit/secondDigit}");
                break;
            case '%':
                Console.WriteLine($"The modulo of {firstDigit} and {secondDigit} is {firstDigit%secondDigit}");
                break;
            default:
                System.Console.WriteLine("Enter a valid operation.");
                break;
        }
    }
}