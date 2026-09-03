using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IPatientAssessment
{
    List<PatientAssessment> GetAllPatientAssessments();

    PatientAssessment? GetPatientAssessmentById(long id);

    bool AddPatientAssessment(PatientAssessment patientAssessment);

    bool UpdatePatientAssessment(PatientAssessment patientAssessment);

    bool DeletePatientAssessmentById(long id);
}