using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientMedicalHistoryController : ControllerBase
{
    private readonly IPatientMedicalHistory _history;

    public PatientMedicalHistoryController(
        IPatientMedicalHistory history)
    {
        _history = history;
    }

    [HttpGet]
    public IActionResult GetAllPatientMedicalHistory()
    {
        return Ok(_history.GetAllPatientMedicalHistory());
    }

    [HttpGet("{id}")]
    public IActionResult GetPatientMedicalHistoryById(long id)
    {
        var history = _history.GetPatientMedicalHistoryById(id);

        if (history == null)
        {
            return NotFound();
        }

        return Ok(history);
    }

    [HttpPost]
    public IActionResult AddPatientMedicalHistory(
        [FromBody] PatientMedicalHistory history)
    {
        return Ok(_history.AddPatientMedicalHistory(history));
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePatientMedicalHistory(
        long id,
        [FromBody] PatientMedicalHistory history)
    {
        history.Id = id;

        return Ok(_history.UpdatePatientMedicalHistory(history));
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePatientMedicalHistoryById(long id)
    {
        var result = _history.DeletePatientMedicalHistoryById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}