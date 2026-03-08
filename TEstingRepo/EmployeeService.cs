using Microsoft.VisualBasic;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public Employee GetEmployeeById(int id)
    {
        if(id <= 0)
        {
            throw new ArgumentException(nameof(id), "Invalid employee ID.");
        }
        var employee = _employeeRepository.GetById(id);
        if(employee == null)
        {
            throw new KeyNotFoundException("Employee not found.");
        }
        return employee;
    }

    
}