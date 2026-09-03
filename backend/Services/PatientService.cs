using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class PatientService : IPatient
{
    private readonly AppDbContext _context;

    public PatientService(AppDbContext context)
    {
        _context = context;
    }

    public List<Patient> GetAllPatient()
    {
        return _context.Patients.ToList();
    }

    public Patient? GetPatientById(long id)
    {
        return _context.Patients.Find(id);
    }

    public bool AddPatient(Patient patient)
    {
        _context.Patients.Add(patient);
        _context.SaveChanges();

        return true;
    }

    public bool UpdatePatient(Patient patient)
    {
        _context.Patients.Update(patient);
        _context.SaveChanges();

        return true;
    }

    public bool DeletePatientById(long id)
    {
        var patient = _context.Patients.Find(id);

        if (patient == null)
        {
            return false;
        }

        _context.Patients.Remove(patient);
        _context.SaveChanges();

        return true;
    }
}