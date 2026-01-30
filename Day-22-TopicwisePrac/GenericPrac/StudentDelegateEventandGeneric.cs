using System;
using System.Collections.Generic;
using System.Linq;

public delegate void Notify();

public class Student
{
    public string? Name { get; set; }
    public int Id { get; set; }
    public int Marks1 { get; set; }
    public int Marks2 { get; set; }

    public event Notify? OnNotify;

    public void OnPass()
    {
        Console.WriteLine("Pass");
    }

    public void OnFail()
    {
        Console.WriteLine("Fail");
    }

    public void SendNotification(Student s)
    {
        OnNotify = null;

        double average = (s.Marks1 + s.Marks2) / 2.0;

        if (average < 40)
        {
            OnNotify = OnFail;
        }
        else
        {
            OnNotify = OnPass;
        }

        OnNotify?.Invoke();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Student notifier = new Student();

        List<Student> marks = new List<Student>
        {
            new Student(){Name="Avishek",Id=1,Marks1=99,Marks2=99},
            new Student(){Name="Varshith",Id=2,Marks1=80,Marks2=69},
            new Student(){Name="Aditya",Id=3,Marks1=71,Marks2=78},
            new Student(){Name="Asad",Id=4,Marks1=30,Marks2=48},
            new Student(){Name="Sreekanth",Id=5,Marks1=34,Marks2=40}
        };

        var result = marks
            .Select(s => new { Student = s, Average = (s.Marks1 + s.Marks2) / 2.0 })
            .OrderByDescending(x => x.Average)
            .ToList();

        int rank = 1;
        foreach (var item in result)
        {
            Console.Write($"{item.Student.Name}'s rank is {rank} (avg {item.Average:F1}) : ");
            notifier.SendNotification(item.Student);
            rank++;
        }
    }
}
