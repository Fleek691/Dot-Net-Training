using System;

public class QuadraticEquation
{       
    /// <summary>
    /// Function to find discriminant and check roots
    /// </summary>
    public static void  Discriminant()
    {
        Console.WriteLine("Enter the value of a: ");
        int a=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the value of b: ");
        int b=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the value of c: ");
        int c=Convert.ToInt32(Console.ReadLine());
        if (a == 0)
        {
            Console.WriteLine("A cannot b 0,ENter the values again");
            Discriminant();
        }
        int disc=b*b-4*a*c;
        if (disc > 0)//if discriminant is positive
        {
            double root1=-b+(Math.Sqrt(disc)/(2*a)) ;
            double root2=-b-(Math.Sqrt(disc)/(2*a));
            Console.WriteLine($"The two roots are  {root1} and {root2}");
        }
        else if (disc == 0)//if discriminant is equal to 0
        {
            double root=-b/(2*a);
            Console.WriteLine($"One real root {root}");
        }
        else//if discriminat is negative
        {
            double realPart=-b/(2*a);
            double imaginaryPart=Math.Sqrt(-disc)/(2*a);
            Console.WriteLine($"Complex roots : {realPart}+{imaginaryPart}i, {realPart}={imaginaryPart}i");
        }
    }
}