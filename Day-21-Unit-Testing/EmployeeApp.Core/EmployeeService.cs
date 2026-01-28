using System.Collections.Generic;

public class EmployeeService
{
    private readonly IEmployeeRepository repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        this.repository = repository;
    }

    public int GetEmployeeCount()
    {
        return repository.GetAll().Count;
    }
}