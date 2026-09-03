using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class AppointmentTypeService : IAppointmentType
{
    private readonly AppDbContext _context;

    public AppointmentTypeService(AppDbContext context)
    {
        _context = context;
    }

    public List<AppointmentType> GetAllAppointmentTypes()
    {
        return _context.AppointmentTypes.ToList();
    }

    public AppointmentType? GetAppointmentTypeById(int id)
    {
        return _context.AppointmentTypes.Find(id);
    }

    public bool AddAppointmentType(AppointmentType appointmentType)
    {
        _context.AppointmentTypes.Add(appointmentType);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateAppointmentType(AppointmentType appointmentType)
    {
        _context.AppointmentTypes.Update(appointmentType);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteAppointmentTypeById(int id)
    {
        var appointmentType = _context.AppointmentTypes.Find(id);

        if (appointmentType == null)
        {
            return false;
        }

        _context.AppointmentTypes.Remove(appointmentType);
        _context.SaveChanges();

        return true;
    }
}