using System;

public class ArmstrongNumber
{
    public static void Armstrong()
    {
        Console.WriteLine("Armstrong Number Checker");
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        
        int originalNumber = number;
        int sum = 0;
        int digitCount = number.ToString().Length;
        
        while (number > 0)
        {
            int digit = number % 10;
            int power = 1;
            for (int i = 0; i < digitCount; i++)
            {
                power *= digit;
            }
            sum += power;
            number /= 10;
        }
        
        if (sum == originalNumber)
        {
            Console.WriteLine($"{originalNumber} is an Armstrong Number.");
        }
        else
        {
            Console.WriteLine($"{originalNumber} is NOT an Armstrong Number.");
        }
    }
}