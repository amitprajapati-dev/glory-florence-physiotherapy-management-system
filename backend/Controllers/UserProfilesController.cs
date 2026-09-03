using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfilesController : ControllerBase
{
    private readonly IUserProfile _userProfile;

    public UserProfilesController(IUserProfile userProfile)
    {
        _userProfile = userProfile;
    }

    [HttpGet]
    public IActionResult GetAllUserProfile()
    {
        return Ok(_userProfile.GetAllUserProfile());
    }

    [HttpGet("{id}")]
    public IActionResult GetUserProfileById(long id)
    {
        var userProfile = _userProfile.GetUserProfileById(id);

        if (userProfile == null)
        {
            return NotFound();
        }

        return Ok(userProfile);
    }

    [HttpPost]
    public IActionResult AddUserProfile(
        [FromBody] UserProfile userProfile)
    {
        return Ok(_userProfile.AddUserProfile(userProfile));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUserProfile(
        long id,
        [FromBody] UserProfile userProfile)
    {
        userProfile.Id = id;

        return Ok(_userProfile.UpdateUserProfile(userProfile));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUserProfileById(long id)
    {
        var result = _userProfile.DeleteUserProfileById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}