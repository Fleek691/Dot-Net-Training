
using System;
using System.Collections.Generic;

class Program4
{
    static void Main(string[] args)
    {
        var manager = new StudentManager();
        manager.AddStudent("Alice", "10th");
        manager.AddStudent("Bob", "10th");
        manager.AddStudent("Charlie", "11th");

        manager.AddGrade(1, "Math", 95);
        manager.AddGrade(1, "Science", 88);
        manager.AddGrade(2, "Math", 78);
        manager.AddGrade(2, "Science", 85);
        manager.AddGrade(3, "Math", 92);
        manager.AddGrade(3, "Science", 90);

        Console.WriteLine("Student Averages:");
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Student {i} Average: {manager.CalculateStudentAverage(i):F2}");
        }

        Console.WriteLine("\nSubject Averages:");
        foreach (var kvp in manager.CalculateSubjectAverages())
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value:F2}");
        }

        Console.WriteLine("\nTop Performers:");
        var top = manager.GetTopPerformers(2);
        foreach (var student in top)
        {
            Console.WriteLine($"{student.Name} (ID: {student.StudentId}) Avg: {student.Subjects.Values.Average():F2}");
        }
    }
}
