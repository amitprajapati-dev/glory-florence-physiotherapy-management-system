using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IAddress _address;

    public AddressesController(IAddress address)
    {
        _address = address;
    }

    [HttpGet]
    public IActionResult GetAllAddress()
    {
        return Ok(_address.GetAllAddress());
    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(long id)
    {
        var address = _address.GetAddressById(id);

        if (address == null)
        {
            return NotFound();
        }

        return Ok(address);
    }

    [HttpPost]
    public IActionResult AddAddress([FromBody] Address address)
    {
        return Ok(_address.AddAddress(address));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(
        long id,
        [FromBody] Address address)
    {
        address.Id = id;

        return Ok(_address.UpdateAddress(address));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddressById(long id)
    {
        var result = _address.DeleteAddressById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}