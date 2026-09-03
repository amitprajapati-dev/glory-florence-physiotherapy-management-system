using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IEmployee
{
    List<Employee> GetAllEmployee();

    Employee GetEmployeeById(int id);

    bool AddEmployee(Employee employee);

    bool UpdateEmployee(Employee employee);

    bool DeleteEmployeeById(int id);
}