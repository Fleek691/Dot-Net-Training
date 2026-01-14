using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;

public class Program
{

    public static void Main(string[] args)
    {
        
        // BasicAndStudentExample();
        // LinqProcessExample();
        // MarksCalculation();        
        LearnLinq.RunDemo();
    }

    private static void MarksCalculation()
    {
        List<Student>students=new List<Student>
        {
            new Student{Name="Avishek",Id=1,Mark1=91,Mark2=80},
            new Student{Name="Asad",Id=2,Mark1=60,Mark2=70},
            new Student{Name="Varshit",Id=3,Mark1=71,Mark2=50},
            new Student{Name="Aditya",Id=4,Mark1=90,Mark2=82},
            new Student{Name="Sreekanth",Id=5,Mark1=85,Mark2=75},

        };
        var studentAverage=from Student in students
                            select new
                            {
                                Student.Id,
                                Student.Name,
                                Average=(Student.Mark1+Student.Mark2)/2
                            };
                            System.Console.WriteLine(studentAverage);
        System.Console.WriteLine("Student Averages: ");
        foreach(var avg in studentAverage)
        {
            System.Console.WriteLine($"{avg.Name} ID: {avg.Id}: {avg.Average}");
        }

        var allMarks=from s in students from mark in new[]{s.Mark1,s.Mark2} select  mark;
        System.Console.WriteLine(allMarks);
        System.Console.WriteLine("All marks: ");
        foreach(var avg in allMarks)
        {
            System.Console.WriteLine(avg);
        }
        
        int topMark=allMarks.Max();
        System.Console.WriteLine($"Top Mark: {topMark}");

        // Alternatively, find the student with the highest average
        var topStudent = studentAverage.OrderByDescending(a => a.Average).First();
        Console.WriteLine($"Top Student by Average: {topStudent.Name} with {topStudent.Average:F2}");

    }

    private static void BasicAndStudentExample()
    {
        string[] names={"Ana","book","tea pot"};
        // var findname=from name in names where name =="b" select name;
        // if(findname!=null)
        //     System.Console.WriteLine("Found name B");
        // var findnames=from name in names select name.ToUpper();
        var findnames=from nam in names orderby nam descending  select new LinqStudent(nam);
        // var findname1=from name in names orderby name descending select name.ToUpper();
        foreach(var item in findnames)
        {
            System.Console.WriteLine(item.name);
            if(item.name!=null)
                System.Console.WriteLine(IsPalindrome(item.name.ToUpper()));
        }
    }
    public static string IsPalindrome(string input)
    {
        string reversed = new string(input.Reverse().ToArray());
        if (input.Equals(reversed))
        {
            return "is Palindrome " + input;
        }
        return "Not Palindrome " + input;
    }
    

    private static void LinqProcessExample()
    {
        // This LINQ query retrieves all running processes on the system.
        // It uses an anonymous type (a temporary, unnamed class) to select and store only the ProcessName and Id properties.
        // Anonymous types are useful for quick, one-time data structures without defining a full class, saving code and memory.
        var processCollection=from pro in System.Diagnostics.Process.GetProcesses() select new {Name=pro.ProcessName,Id=pro.Id};
        foreach(var process in processCollection)
        {
            System.Console.WriteLine($"Process Name: {process.Name} Process Id: {process.Id}");
        }
    }

    
    public class LinqStudent{
        public string? name{get;set;}
        public LinqStudent(string Name)
        {
            this.name=Name;
        }
        
    }
    // This is an explicit class used for storing process information (Name and Id).
    // Unlike anonymous types, this class can be reused throughout the program,
    // making it suitable for scenarios where you need to pass or store process data in multiple places.
    public class MyProcess{
        public string? Name{get;set;}
        public int Id{get;set;}
    }

}