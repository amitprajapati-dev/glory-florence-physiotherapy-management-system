using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IRole _role;

    public RolesController(IRole role)
    {
        _role = role;
    }

    [HttpGet]
    public IActionResult GetAllRole()
    {
        return Ok(_role.GetAllRole());
    }

    [HttpGet("{id}")]
    public IActionResult GetRoleById(int id)
    {
        var role = _role.GetRoleById(id);

        if (role == null)
        {
            return NotFound();
        }

        return Ok(role);
    }

    [HttpPost]
    public IActionResult AddRole([FromBody] Role role)
    {
        return Ok(_role.AddRole(role));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRole(
        int id,
        [FromBody] Role role)
    {
        role.Id = id;

        return Ok(_role.UpdateRole(role));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRoleById(int id)
    {
        var result = _role.DeleteRoleById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}