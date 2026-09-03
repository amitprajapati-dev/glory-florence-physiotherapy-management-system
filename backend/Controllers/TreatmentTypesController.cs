using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreatmentTypesController : ControllerBase
{
    private readonly ITreatmentType _treatmentType;

    public TreatmentTypesController(ITreatmentType treatmentType)
    {
        _treatmentType = treatmentType;
    }

    [HttpGet]
    public IActionResult GetAllTreatmentType()
    {
        return Ok(_treatmentType.GetAllTreatmentType());
    }

    [HttpGet("{id}")]
    public IActionResult GetTreatmentTypeById(int id)
    {
        var treatmentType = _treatmentType.GetTreatmentTypeById(id);

        if (treatmentType == null)
        {
            return NotFound();
        }

        return Ok(treatmentType);
    }

    [HttpPost]
    public IActionResult AddTreatmentType(
        [FromBody] TreatmentType treatmentType)
    {
        return Ok(_treatmentType.AddTreatmentType(treatmentType));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTreatmentType(
        int id,
        [FromBody] TreatmentType treatmentType)
    {
        treatmentType.Id = id;

        return Ok(_treatmentType.UpdateTreatmentType(treatmentType));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTreatmentTypeById(int id)
    {
        var result = _treatmentType.DeleteTreatmentTypeById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}