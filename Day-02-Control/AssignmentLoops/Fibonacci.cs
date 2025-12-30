using System;

public class Fibonacci()
{
    public static void IFFib()
    {
        Console.Write("Enter the nth term: ");
        int n=Convert.ToInt32(Console.ReadLine());

        int a=0;
        int b=1;
        System.Console.Write($"{a} {b} ");
        for(int i = 0; i < n-2; i++)
        {
            int temp=a+b;
            Console.Write(temp+" ");
            a=b;
            b=temp;

        }
    }
}