using System.Collections.Generic;

public interface IEmployeeRepository
{
    List<Employee> GetAll();
    int GetId();
}
