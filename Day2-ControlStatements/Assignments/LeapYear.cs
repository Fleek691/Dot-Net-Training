using System;

public class LeapYear
{
    /// <summary>
    /// Function for Checking a year is Leap year or not
    /// </summary>
    /// <param name="year"></param>
    public static void CheckLY(int year)
    {
        if(year %400==0 || (year%4==0 && year % 100 != 0))
        {
            Console.WriteLine($"{year} is a Leap Year");
        }
        else
        {
            Console.WriteLine($"{year} is not a Leap year");
        }
    }
}