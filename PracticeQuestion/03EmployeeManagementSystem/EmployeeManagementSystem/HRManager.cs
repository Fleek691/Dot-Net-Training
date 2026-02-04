public class HRManager
{
    private SortedDictionary<int, Employee> employeeDetails = new SortedDictionary<int, Employee>();
    int id=1;
    public void AddEmployee(string name, string dept, double salary)
    {
        
        employeeDetails.Add(id,new Employee(id,name,dept,salary,DateTime.Now));
        id++;
    }
    // Auto-generate EmployeeId (E001, E002...)

    public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
    {
        var result = employeeDetails.Values
            .GroupBy(emp => emp.Department)
            .ToDictionary(group => group.Key, group => group.ToList());
        return new SortedDictionary<string, List<Employee>>(result);
    }
    // Groups employees by department

    public double CalculateDepartmentSalary(string department){
        var res=employeeDetails.Values.Where(e=>e.Department==department).Sum(e=>e.Salary);
        return res;
    }
    // Returns total salary of a department

    public List<Employee> GetEmployeesJoinedAfter(DateTime date){
        var res=employeeDetails.Values.Where(e=>e.JoiningDate>date).ToList();
        return res;
    }
    // Returns employees joined after specific date
    

}