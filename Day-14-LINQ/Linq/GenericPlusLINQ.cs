public class EmployeeRe
{
    public int Id{get;set;}
    public string? Name{get;set;}
    public int Rank{get;set;}
}
public class ExampleOfGenericAndLinq
{
    public static List<EmployeeRe> employeeRes=new List<EmployeeRe>();
    public static void Main(string[] args)
    {
        var LocalEmpList=GetData();
        var filteredList=from emp in LocalEmpList select emp;//how own value?
        System.Console.WriteLine(filteredList);
        System.Console.WriteLine(LocalEmpList);
        foreach(var emp in filteredList)
        {
            System.Console.WriteLine(emp.Name);
        }
    }
    public static List<EmployeeRe> GetData()
    {
        employeeRes.Add(new EmployeeRe(){Id=1,Name="Aa",Rank=1});
        employeeRes.Add(new EmployeeRe(){Id=1,Name="Aa",Rank=1});
        employeeRes.Add(new EmployeeRe(){Id=1,Name="Aa",Rank=1});
        employeeRes.Add(new EmployeeRe(){Id=1,Name="Aa",Rank=1});
        return employeeRes;

    }
    
}