using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecializationsController : ControllerBase
{
    private readonly ISpecialization _specialization;

    public SpecializationsController(ISpecialization specialization)
    {
        _specialization = specialization;
    }

    [HttpGet]
    public IActionResult GetAllSpecialization()
    {
        return Ok(_specialization.GetAllSpecialization());
    }

    [HttpGet("{id}")]
    public IActionResult GetSpecializationById(int id)
    {
        var specialization = _specialization.GetSpecializationById(id);

        if (specialization == null)
        {
            return NotFound();
        }

        return Ok(specialization);
    }

    [HttpPost]
    public IActionResult AddSpecialization(
        [FromBody] Specialization specialization)
    {
        return Ok(_specialization.AddSpecialization(specialization));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateSpecialization(
        int id,
        [FromBody] Specialization specialization)
    {
        specialization.Id = id;

        return Ok(_specialization.UpdateSpecialization(specialization));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSpecializationById(int id)
    {
        var result = _specialization.DeleteSpecializationById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}