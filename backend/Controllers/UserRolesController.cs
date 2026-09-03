using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRolesController : ControllerBase
{
    private readonly IUserRole _userRole;

    public UserRolesController(IUserRole userRole)
    {
        _userRole = userRole;
    }

    [HttpGet]
    public IActionResult GetAllUserRole()
    {
        return Ok(_userRole.GetAllUserRole());
    }

    [HttpGet("{id}")]
    public IActionResult GetUserRoleById(long id)
    {
        var userRole = _userRole.GetUserRoleById(id);

        if (userRole == null)
        {
            return NotFound();
        }

        return Ok(userRole);
    }

    [HttpPost]
    public IActionResult AddUserRole([FromBody] UserRole userRole)
    {
        return Ok(_userRole.AddUserRole(userRole));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUserRole(
        long id,
        [FromBody] UserRole userRole)
    {
        userRole.Id = id;

        return Ok(_userRole.UpdateUserRole(userRole));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUserRoleById(long id)
    {
        var result = _userRole.DeleteUserRoleById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}