using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    private readonly ICity _city;

    public CitiesController(ICity city)
    {
        _city = city;
    }

    [HttpGet]
    public IActionResult GetAllCity()
    {
        return Ok(_city.GetAllCity());
    }

    [HttpGet("{id}")]
    public IActionResult GetCityById(int id)
    {
        var city = _city.GetCityById(id);

        if (city == null)
        {
            return NotFound();
        }

        return Ok(city);
    }

    [HttpPost]
    public IActionResult AddCity([FromBody] City city)
    {
        return Ok(_city.AddCity(city));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCity(
        int id,
        [FromBody] City city)
    {
        city.Id = id;

        return Ok(_city.UpdateCity(city));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCityById(int id)
    {
        var result = _city.DeleteCityById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}