using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployee _employee;

    public EmployeesController(IEmployee employee)
    {
        _employee = employee;
    }

    [HttpGet]
    public IActionResult GetAllEmployee()
    {
        return Ok(_employee.GetAllEmployee());
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeById(int id)
    {
        var employee = _employee.GetEmployeeById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost]
    public IActionResult AddEmployee([FromBody] Employee employee)
    {
        return Ok(_employee.AddEmployee(employee));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
    {
        employee.Id = id;

        return Ok(_employee.UpdateEmployee(employee));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEmployeeById(int id)
    {
        var result = _employee.DeleteEmployeeById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}