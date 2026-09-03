using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IAppointment
{
    List<Appointment> GetAllAppointments();

    Appointment? GetAppointmentById(long id);

    bool AddAppointment(Appointment appointment);

    bool UpdateAppointment(Appointment appointment);

    bool DeleteAppointmentById(long id);
}