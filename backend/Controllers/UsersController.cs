using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUser _user;

    public UsersController(IUser user)
    {
        _user = user;
    }

    [HttpGet]
    public IActionResult GetAllUser()
    {
        return Ok(_user.GetAllUser());
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _user.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] User user)
    {
        return Ok(_user.AddUser(user));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(
        int id,
        [FromBody] User user)
    {
        user.Id = id;

        return Ok(_user.UpdateUser(user));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUserById(int id)
    {
        var result = _user.DeleteUserById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}