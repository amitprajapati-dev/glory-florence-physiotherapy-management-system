using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class PatientAssessmentService : IPatientAssessment
{
    private readonly AppDbContext _context;

    public PatientAssessmentService(AppDbContext context)
    {
        _context = context;
    }

    public List<PatientAssessment> GetAllPatientAssessments()
    {
        return _context.PatientAssessments.ToList();
    }

    public PatientAssessment? GetPatientAssessmentById(long id)
    {
        return _context.PatientAssessments.Find(id);
    }

    public bool AddPatientAssessment(PatientAssessment patientAssessment)
    {
        _context.PatientAssessments.Add(patientAssessment);
        _context.SaveChanges();

        return true;
    }

    public bool UpdatePatientAssessment(PatientAssessment patientAssessment)
    {
        _context.PatientAssessments.Update(patientAssessment);
        _context.SaveChanges();

        return true;
    }

    public bool DeletePatientAssessmentById(long id)
    {
        var patientAssessment = _context.PatientAssessments.Find(id);

        if (patientAssessment == null)
        {
            return false;
        }

        _context.PatientAssessments.Remove(patientAssessment);
        _context.SaveChanges();

        return true;
    }
}