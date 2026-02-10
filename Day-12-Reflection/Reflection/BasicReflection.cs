using System;
using System.Reflection;
using System.Runtime.ConstrainedExecution;


public class Employee
{
    // ===== Fields =====
    public int Id;
    private double salary;
    protected string department = "IT";
    internal string company = "ABC Corp";

    // ===== Properties =====
    public string? Name { get; set; }
    private int Age { get; set; }
    protected string? Address { get; set; }
    internal string? Email { get; set; }

    // ===== Constructors =====
    public Employee()
    {
        Id = 1;
        salary = 0;
        Name = "Avishek";
    }

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
        salary = 25000;
    }

    // ===== Public Methods =====
    public static void DisplayPublic()
    {
        Console.WriteLine("Public Method Called");
    }

    public string GetEmployeeInfo()
    {
        return $"{Id} - {Name}";
    }

    // ===== Private Method =====
    private void CalculateSalary()
    {
        salary += 1000;
    }

    // ===== Protected Method =====
    protected void ProtectedMethod()
    {
        Console.WriteLine("Protected Method");
    }

    // ===== Internal Method =====
    internal void InternalMethod()
    {
        Console.WriteLine("Internal Method");
    }

    // ===== Static Method =====
    public static void StaticMethod()
    {
        Console.WriteLine("Static Method");
    }

    // ===== Overloaded Methods =====
    public void PrintData(string msg)
    {
        Console.WriteLine(msg);
    }

    public void PrintData(string msg, int number)
    {
        Console.WriteLine($"{msg} {number}");
    }

    // ===== Virtual Method (for advanced reflection later) =====
    public virtual void VirtualMethod()
    {
        Console.WriteLine("Employee Virtual Method");
    }
}


public class Program1
{
    public static void Main()
    {
        Type t = typeof(Employee);
        System.Console.WriteLine(t);//Getting type of the class
        var methods = t.GetMethods();
        System.Console.WriteLine();
        foreach (var item in methods)
        {
            System.Console.WriteLine(item);
        }//Printing all the methods
        System.Console.WriteLine();
        var method = t.GetMethod("GetEmployeeInfo");

        Employee emp = new Employee();
        var result = method?.Invoke(emp, null);
        System.Console.WriteLine(result);
        System.Console.WriteLine();
        var method1 = t.GetMethod("PrintData", new Type[] { typeof(string) });//second parameter to specify which method since there are two one is overloaded
        method1?.Invoke(emp, new object[] { "Avishek" });
        System.Console.WriteLine();
        var method2 = t.GetMethod("PrintData", new Type[] { typeof(string), typeof(int) });//second parameter to specify which method since there are two one is overloaded
        method2?.Invoke(emp, new object[] { "Avishek", 100 });
        System.Console.WriteLine();
        var props = t.GetProperties();
        foreach (var item in props)
        {
            System.Console.WriteLine(item);
        }
        var propeUsage = t.GetProperty("Name");
        System.Console.WriteLine(propeUsage?.GetValue(emp));
        propeUsage?.SetValue(emp, "Avishek Prasad");
        System.Console.WriteLine(propeUsage?.GetValue(emp));

        System.Console.WriteLine();
        var fieldss = t.GetFields();
        foreach (var item in fieldss)
        {
            System.Console.WriteLine((item));
        }
        var fieldUsage = t.GetField("Id");
        System.Console.WriteLine(fieldUsage?.GetValue(emp));
        System.Console.WriteLine();
        System.Console.WriteLine();

        var privateProp = t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var item in privateProp)
        {
            System.Console.WriteLine(item);
        }
        var ageProp = t.GetProperty("Age", BindingFlags.NonPublic | BindingFlags.Instance);
        System.Console.WriteLine(ageProp?.GetValue(emp));
        ageProp?.SetValue(emp, 22);
        System.Console.WriteLine(ageProp?.GetValue(emp));
        System.Console.WriteLine();
        var privateFields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var item in privateFields)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine();
        var salaryField = t.GetField("salary", BindingFlags.NonPublic | BindingFlags.Instance);
        System.Console.WriteLine(salaryField?.GetValue(emp));
        salaryField?.SetValue(emp, 100000);
        System.Console.WriteLine(salaryField?.GetValue(emp));
        System.Console.WriteLine();
        var privateMethods = t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var item in privateMethods)
        {
            System.Console.WriteLine(item);
        }
        var CalculateSalaryMethod = t.GetMethod("CalculateSalary", BindingFlags.NonPublic | BindingFlags.Instance);
        CalculateSalaryMethod?.Invoke(emp, null);
        System.Console.WriteLine(salaryField?.GetValue(emp));
        System.Console.WriteLine();
        var staticMethods = t.GetMethods(BindingFlags.Public | BindingFlags.Static);
        foreach (var item in staticMethods)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine();
        var privateMethodsDeclaredOnly = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var item in privateMethods)
        {
            System.Console.WriteLine(item);
        }
    }
}