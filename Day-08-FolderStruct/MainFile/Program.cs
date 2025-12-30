using System;
using StudentSessionApp.Model;
using StudentSessionApp.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var students = DataBank.GetStudents();
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
        }
        var sessions= DataBank.GetStudentSessions();
        foreach(var session in sessions){
            System.Console.WriteLine($"Session ID: {session.Id}, Session Name{session.Name}");
        }
    }
}