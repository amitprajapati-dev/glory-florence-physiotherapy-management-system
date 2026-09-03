using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentTypesController : ControllerBase
{
    private readonly IAppointmentType _appointmentType;

    public AppointmentTypesController(IAppointmentType appointmentType)
    {
        _appointmentType = appointmentType;
    }

    [HttpGet]
    public IActionResult GetAllAppointmentTypes()
    {
        return Ok(_appointmentType.GetAllAppointmentTypes());
    }

    [HttpGet("{id}")]
    public IActionResult GetAppointmentTypeById(int id)
    {
        var appointmentType = _appointmentType.GetAppointmentTypeById(id);

        if (appointmentType == null)
        {
            return NotFound();
        }

        return Ok(appointmentType);
    }

    [HttpPost]
    public IActionResult AddAppointmentType(
        [FromBody] AppointmentType appointmentType)
    {
        return Ok(_appointmentType.AddAppointmentType(appointmentType));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAppointmentType(
        int id,
        [FromBody] AppointmentType appointmentType)
    {
        appointmentType.Id = id;

        return Ok(_appointmentType.UpdateAppointmentType(appointmentType));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAppointmentTypeById(int id)
    {
        var result = _appointmentType.DeleteAppointmentTypeById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}