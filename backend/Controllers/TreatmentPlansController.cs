using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreatmentPlansController : ControllerBase
{
    private readonly ITreatmentPlan _treatmentPlan;

    public TreatmentPlansController(ITreatmentPlan treatmentPlan)
    {
        _treatmentPlan = treatmentPlan;
    }

    [HttpGet]
    public IActionResult GetAllTreatmentPlans()
    {
        return Ok(_treatmentPlan.GetAllTreatmentPlans());
    }

    [HttpGet("{id}")]
    public IActionResult GetTreatmentPlanById(long id)
    {
        var treatmentPlan =
            _treatmentPlan.GetTreatmentPlanById(id);

        if (treatmentPlan == null)
        {
            return NotFound();
        }

        return Ok(treatmentPlan);
    }

    [HttpPost]
    public IActionResult AddTreatmentPlan(
        [FromBody] TreatmentPlan treatmentPlan)
    {
        return Ok(
            _treatmentPlan.AddTreatmentPlan(treatmentPlan));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTreatmentPlan(
        long id,
        [FromBody] TreatmentPlan treatmentPlan)
    {
        treatmentPlan.Id = id;

        return Ok(
            _treatmentPlan.UpdateTreatmentPlan(treatmentPlan));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTreatmentPlanById(long id)
    {
        var result =
            _treatmentPlan.DeleteTreatmentPlanById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}