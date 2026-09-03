using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountry _country;

    public CountriesController(ICountry country)
    {
        _country = country;
    }

    [HttpGet]
    public IActionResult GetAllCountry()
    {
        return Ok(_country.GetAllCountry());
    }

    [HttpGet("{id}")]
    public IActionResult GetCountryById(int id)
    {
        var country = _country.GetCountryById(id);

        if (country == null)
        {
            return NotFound();
        }

        return Ok(country);
    }

    [HttpPost]
    public IActionResult AddCountry([FromBody] Country country)
    {
        return Ok(_country.AddCountry(country));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCountry(
        int id,
        [FromBody] Country country)
    {
        country.Id = id;

        return Ok(_country.UpdateCountry(country));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCountryById(int id)
    {
        var result = _country.DeleteCountryById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}