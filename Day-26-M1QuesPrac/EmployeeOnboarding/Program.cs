public class Employee
{
    public int Id{get;set;}
    public string Name{get;set;}
    public string Email{get;set;}
    public double Salary{get;set;}
    public Employee(){}
    public Employee(int id,string name,string email,double salary)
    {
        Id=id;
        Name=name;
        if (!email.Contains("@"))
        {
            Email="unknown@company.com";
        }
        else
        {
            Email=email;
        }
        if (salary <= 0)
        {
            Salary=30000;
        }
        else
        {
            Salary=salary;
        }
    }
}

public class Helper
{
    public static void Main()
    {
        Employee emp1=new Employee(1,"Avishek","avsihekprasadgmail.com",20000);
        Employee emp2=new Employee(2,"Aditya","aditya@gmail.com",0);
        Employee emp3=new Employee(3,"Varshit","varshit",-2);
        System.Console.WriteLine($"{emp1.Id}, {emp1.Name}, {emp1.Email} ,{emp1.Salary}");
        System.Console.WriteLine($"{emp2.Id}, {emp2.Name}, {emp2.Email} ,{emp2.Salary}");
        System.Console.WriteLine($"{emp3.Id}, {emp3.Name}, {emp3.Email} ,{emp3.Salary}");
    }
}