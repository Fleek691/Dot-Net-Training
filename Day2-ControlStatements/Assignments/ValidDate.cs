using System;
public class ValidDate
{
    public static void isValid()
    {
        Console.Write("Enter day: ");
        int day=Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine();
        Console.Write("Enter Month: ");
        int month=Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine();
        Console.Write("Eter Year: ");
        int year=Convert.ToInt32(Console.ReadLine());
        System.Console.WriteLine();

        if(day<=0 || month<1 || month>12 || year <= 0)
        {
            Console.WriteLine("Enter a Valid Date:)");
            return;
        }

        int daysInMonth;

        if (month == 2)
        {
            bool isLeap=(year %400==0 || (year%4==0 && year % 100 != 0));
            daysInMonth=isLeap?29:28;
        }else if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            daysInMonth=30;
        }
        else
        {
            daysInMonth=31;
        }
        if (day <= daysInMonth)
        {
            Console.WriteLine("Valid Date!!");
        }
        else
        {
            Console.WriteLine("Invalid Date.");
        }
    }
}