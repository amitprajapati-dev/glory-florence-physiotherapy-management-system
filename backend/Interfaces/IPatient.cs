using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IPatient
{
    List<Patient> GetAllPatient();

    Patient? GetPatientById(long id);

    bool AddPatient(Patient patient);

    bool UpdatePatient(Patient patient);

    bool DeletePatientById(long id);
}