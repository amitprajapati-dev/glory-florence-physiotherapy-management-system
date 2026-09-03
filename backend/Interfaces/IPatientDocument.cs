using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IPatientDocument
{
    List<PatientDocument> GetAllPatientDocument();

    PatientDocument? GetPatientDocumentById(long id);

    bool AddPatientDocument(PatientDocument document);

    bool UpdatePatientDocument(PatientDocument document);

    bool DeletePatientDocumentById(long id);
}