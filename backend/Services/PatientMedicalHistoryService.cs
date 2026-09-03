using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class PatientMedicalHistoryService : IPatientMedicalHistory
{
    private readonly AppDbContext _context;

    public PatientMedicalHistoryService(AppDbContext context)
    {
        _context = context;
    }

    public List<PatientMedicalHistory> GetAllPatientMedicalHistory()
    {
        return _context.PatientMedicalHistories.ToList();
    }

    public PatientMedicalHistory? GetPatientMedicalHistoryById(long id)
    {
        return _context.PatientMedicalHistories.Find(id);
    }

    public bool AddPatientMedicalHistory(
        PatientMedicalHistory history)
    {
        _context.PatientMedicalHistories.Add(history);
        _context.SaveChanges();

        return true;
    }

    public bool UpdatePatientMedicalHistory(
        PatientMedicalHistory history)
    {
        _context.PatientMedicalHistories.Update(history);
        _context.SaveChanges();

        return true;
    }

    public bool DeletePatientMedicalHistoryById(long id)
    {
        var history = _context.PatientMedicalHistories.Find(id);

        if (history == null)
        {
            return false;
        }

        _context.PatientMedicalHistories.Remove(history);
        _context.SaveChanges();

        return true;
    }
}