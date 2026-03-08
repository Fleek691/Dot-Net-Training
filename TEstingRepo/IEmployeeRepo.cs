public interface IEmployeeRepository
{
    Employee? GetById(int id);
    IReadOnlyList<Employee> GetAll();
    void Add(Employee employee);
    void Update(Employee employee);
    void Delete(int id);
}