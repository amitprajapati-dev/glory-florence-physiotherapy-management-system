using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IPatientMedicalHistory
{
    List<PatientMedicalHistory> GetAllPatientMedicalHistory();

    PatientMedicalHistory? GetPatientMedicalHistoryById(long id);

    bool AddPatientMedicalHistory(PatientMedicalHistory history);

    bool UpdatePatientMedicalHistory(PatientMedicalHistory history);

    bool DeletePatientMedicalHistoryById(long id);
}