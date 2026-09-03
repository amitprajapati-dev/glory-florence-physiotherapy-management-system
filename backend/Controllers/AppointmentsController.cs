using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointment _appointment;

    public AppointmentsController(IAppointment appointment)
    {
        _appointment = appointment;
    }

    [HttpGet]
    public IActionResult GetAllAppointments()
    {
        return Ok(_appointment.GetAllAppointments());
    }

    [HttpGet("{id}")]
    public IActionResult GetAppointmentById(long id)
    {
        var appointment = _appointment.GetAppointmentById(id);

        if (appointment == null)
        {
            return NotFound();
        }

        return Ok(appointment);
    }

    [HttpPost]
    public IActionResult AddAppointment(
        [FromBody] Appointment appointment)
    {
        return Ok(_appointment.AddAppointment(appointment));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAppointment(
        long id,
        [FromBody] Appointment appointment)
    {
        appointment.Id = id;

        return Ok(_appointment.UpdateAppointment(appointment));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAppointmentById(long id)
    {
        var result = _appointment.DeleteAppointmentById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}