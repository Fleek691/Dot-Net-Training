public class Employee
{
    public int EmployeeId{get;set;}
    public string Name{get;set;}
    public string Department{get;set;}
    public double Salary{get;set;}
    public DateTime JoiningDate{get;set;}
    public Employee(int id,string name,string dept,double salary,DateTime date)
    {
        EmployeeId=id;
        Name=name;
        Department=dept;
        Salary=salary;
        JoiningDate=date;
    }
}