using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class AppointmentService : IAppointment
{
    private readonly AppDbContext _context;

    public AppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public List<Appointment> GetAllAppointments()
    {
        return _context.Appointments.ToList();
    }

    public Appointment? GetAppointmentById(long id)
    {
        return _context.Appointments.Find(id);
    }

    public bool AddAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateAppointment(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteAppointmentById(long id)
    {
        var appointment = _context.Appointments.Find(id);

        if (appointment == null)
        {
            return false;
        }

        _context.Appointments.Remove(appointment);
        _context.SaveChanges();

        return true;
    }
}