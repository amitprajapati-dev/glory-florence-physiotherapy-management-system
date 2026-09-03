using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreatmentSessionsController : ControllerBase
{
    private readonly ITreatmentSession _treatmentSession;

    public TreatmentSessionsController(
        ITreatmentSession treatmentSession)
    {
        _treatmentSession = treatmentSession;
    }

    [HttpGet]
    public IActionResult GetAllTreatmentSessions()
    {
        return Ok(_treatmentSession.GetAllTreatmentSessions());
    }

    [HttpGet("{id}")]
    public IActionResult GetTreatmentSessionById(long id)
    {
        var treatmentSession =
            _treatmentSession.GetTreatmentSessionById(id);

        if (treatmentSession == null)
        {
            return NotFound();
        }

        return Ok(treatmentSession);
    }

    [HttpPost]
    public IActionResult AddTreatmentSession(
        [FromBody] TreatmentSession treatmentSession)
    {
        return Ok(
            _treatmentSession.AddTreatmentSession(treatmentSession));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTreatmentSession(
        long id,
        [FromBody] TreatmentSession treatmentSession)
    {
        treatmentSession.Id = id;

        return Ok(
            _treatmentSession.UpdateTreatmentSession(treatmentSession));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTreatmentSessionById(long id)
    {
        var result =
            _treatmentSession.DeleteTreatmentSessionById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}