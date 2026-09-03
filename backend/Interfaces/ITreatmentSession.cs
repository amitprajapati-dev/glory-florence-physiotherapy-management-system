using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface ITreatmentSession
{
    List<TreatmentSession> GetAllTreatmentSessions();

    TreatmentSession? GetTreatmentSessionById(long id);

    bool AddTreatmentSession(TreatmentSession treatmentSession);

    bool UpdateTreatmentSession(TreatmentSession treatmentSession);

    bool DeleteTreatmentSessionById(long id);
}