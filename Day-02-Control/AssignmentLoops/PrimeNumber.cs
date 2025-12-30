using System;

public class PrimeNumber
{
    public static void IsPrime()
    {
        Console.Write("Enter the number you want to check for Prime: ");
        int num=Convert.ToInt32(Console.ReadLine());
        bool isprime=true;
        for(int i = 2; i <= (num / 2); i++)
        {
            if (num % i == 0)
            {
                isprime=false;
                break;
            }
        }
        if(isprime)Console.Write("The number is Prime");
        else
        {
            System.Console.WriteLine("Not Prime");
        }
    }
}