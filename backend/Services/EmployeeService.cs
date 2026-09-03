using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Repositories;

public class EmployeeService : IEmployee
{
    private readonly AppDbContext _context;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public List<Employee> GetAllEmployee()
    {
        return _context.Employees.ToList();
    }

    public Employee GetEmployeeById(int id)
    {
        return _context.Employees.Find(id);
    }

    public bool AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateEmployee(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteEmployeeById(int id)
    {
        var employee = _context.Employees.Find(id);

        if (employee == null)
        {
            return false;
        }

        _context.Employees.Remove(employee);
        _context.SaveChanges();

        return true;
    }
}