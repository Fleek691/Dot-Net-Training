using System;

public class TriangleType
{
    /// <summary>
    /// Function to Check the Type of Triangle
    /// </summary>
    public static void CheckTriangle()
    {
        //Taking User input for each side of a Triangle
        Console.Write("Enter side a: ");
        double a=Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter side b: ");
        double b=Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter side c: ");
        double c=Convert.ToDouble(Console.ReadLine());

        //Checking if the Triangle is valid and if yes then the type
        if(a+b<=c || a+c<=b || b + c <= a)
        {
            System.Console.WriteLine("Not a valid triangle");
        }
        else if(a==b && b == c)//When all three sides are equal
        {
            System.Console.WriteLine("This is an Equilateral Triangle");
        }
        else if(a==b || b==c || c==a)//When any two sides are equal
        {
            System.Console.WriteLine("This is an Isoceles Triangle");
        }
        else//None of the sides are same
        {
            System.Console.WriteLine("This is a scalene Triangle");
        }
    }
}