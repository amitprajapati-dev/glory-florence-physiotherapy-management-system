using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IAppointmentType
{
    List<AppointmentType> GetAllAppointmentTypes();

    AppointmentType? GetAppointmentTypeById(int id);

    bool AddAppointmentType(AppointmentType appointmentType);

    bool UpdateAppointmentType(AppointmentType appointmentType);

    bool DeleteAppointmentTypeById(int id);
}