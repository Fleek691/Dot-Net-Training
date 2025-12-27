using System;
using Microsoft.VisualBasic;

public class MenuSystem
{
    public static void CheckChoice()
    {
        int choice;
        do
        {
            Console.WriteLine("====Menu===");
            Console.WriteLine("1. Add two Numbers");
            Console.WriteLine("2. Subtract two Numbers");
            Console.WriteLine("3. Even or Odd");
            Console.WriteLine("4. Greetings");
            Console.WriteLine("0. Exit");            
            Console.Write("Enter your choice: ");

            choice=Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    System.Console.Write("Enter First Digit: ");
                    int first=Convert.ToInt16(Console.ReadLine());
                    System.Console.Write("Enter second Number: ");
                    int second=Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine($"The sum of {first} and {second} is {first+second}");
                    break;
                case 2:
                    System.Console.Write("Enter First Digit: ");
                    int firstN=Convert.ToInt16(Console.ReadLine());
                    System.Console.Write("Enter second Number: ");
                    int secondN=Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine($"The subtraction of {firstN} and {secondN} is {firstN-secondN}");
                    break;
                case 3:
                    System.Console.Write("Enter Digit: ");
                    int num=Convert.ToInt16(Console.ReadLine());      
                    string result=num%2==0?"Even":"Odd";             
                    Console.WriteLine($"The num is {result}");
                    break;
                case 4:
                    System.Console.WriteLine("Good Evening Boss");
                    break;
                case 0:
                    System.Console.WriteLine("Exiting Program");
                    break;
                default:
                    System.Console.WriteLine("Enter a valid choice!!");
                    break;
            }
        }while(choice!=0);
    }
}