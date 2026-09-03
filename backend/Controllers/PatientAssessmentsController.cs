using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientAssessmentsController : ControllerBase
{
    private readonly IPatientAssessment _patientAssessment;

    public PatientAssessmentsController(
        IPatientAssessment patientAssessment)
    {
        _patientAssessment = patientAssessment;
    }

    [HttpGet]
    public IActionResult GetAllPatientAssessments()
    {
        return Ok(_patientAssessment.GetAllPatientAssessments());
    }

    [HttpGet("{id}")]
    public IActionResult GetPatientAssessmentById(long id)
    {
        var patientAssessment =
            _patientAssessment.GetPatientAssessmentById(id);

        if (patientAssessment == null)
        {
            return NotFound();
        }

        return Ok(patientAssessment);
    }

    [HttpPost]
    public IActionResult AddPatientAssessment(
        [FromBody] PatientAssessment patientAssessment)
    {
        return Ok(
            _patientAssessment.AddPatientAssessment(patientAssessment));
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePatientAssessment(
        long id,
        [FromBody] PatientAssessment patientAssessment)
    {
        patientAssessment.Id = id;

        return Ok(
            _patientAssessment.UpdatePatientAssessment(patientAssessment));
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePatientAssessmentById(long id)
    {
        var result =
            _patientAssessment.DeletePatientAssessmentById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}