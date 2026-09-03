using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatient _patient;

    public PatientsController(IPatient patient)
    {
        _patient = patient;
    }

    [HttpGet]
    public IActionResult GetAllPatient()
    {
        return Ok(_patient.GetAllPatient());
    }

    [HttpGet("{id}")]
    public IActionResult GetPatientById(long id)
    {
        var patient = _patient.GetPatientById(id);

        if (patient == null)
        {
            return NotFound();
        }

        return Ok(patient);
    }

    [HttpPost]
    public IActionResult AddPatient([FromBody] Patient patient)
    {
        return Ok(_patient.AddPatient(patient));
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePatient(
        long id,
        [FromBody] Patient patient)
    {
        patient.Id = id;

        return Ok(_patient.UpdatePatient(patient));
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePatientById(long id)
    {
        var result = _patient.DeletePatientById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}