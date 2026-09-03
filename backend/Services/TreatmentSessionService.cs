using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class TreatmentSessionService : ITreatmentSession
{
    private readonly AppDbContext _context;

    public TreatmentSessionService(AppDbContext context)
    {
        _context = context;
    }

    public List<TreatmentSession> GetAllTreatmentSessions()
    {
        return _context.TreatmentSessions.ToList();
    }

    public TreatmentSession? GetTreatmentSessionById(long id)
    {
        return _context.TreatmentSessions.Find(id);
    }

    public bool AddTreatmentSession(
        TreatmentSession treatmentSession)
    {
        _context.TreatmentSessions.Add(treatmentSession);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateTreatmentSession(
        TreatmentSession treatmentSession)
    {
        _context.TreatmentSessions.Update(treatmentSession);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteTreatmentSessionById(long id)
    {
        var treatmentSession = _context.TreatmentSessions.Find(id);

        if (treatmentSession == null)
        {
            return false;
        }

        _context.TreatmentSessions.Remove(treatmentSession);
        _context.SaveChanges();

        return true;
    }
}