using System;

public class GradeDescription
{
    public static void CheckGrade()
    {
        Console.WriteLine("Enter Grade: ");
        string? g=Console.ReadLine();
        if (string.IsNullOrEmpty(g))
        {
            Console.WriteLine("Enter A grade");
        }
        char grade=char.ToUpper(g[0]);
        switch (grade)
        {
            case 'E':
                Console.WriteLine("Excellent");
                break;
            case 'V':
                Console.WriteLine("Very good");
                break;
            case 'G':
                Console.WriteLine("Good");
                break;
            case 'A':
                Console.WriteLine("Average");
                break;
            case 'F':
                Console.WriteLine("Fail");
                break;
            default:
                System.Console.WriteLine("Enter a valid grade");
                break;

        }
    }
}