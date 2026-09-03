using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class PatientDocumentService : IPatientDocument
{
    private readonly AppDbContext _context;

    public PatientDocumentService(AppDbContext context)
    {
        _context = context;
    }

    public List<PatientDocument> GetAllPatientDocument()
    {
        return _context.PatientDocuments.ToList();
    }

    public PatientDocument? GetPatientDocumentById(long id)
    {
        return _context.PatientDocuments.Find(id);
    }

    public bool AddPatientDocument(PatientDocument document)
    {
        _context.PatientDocuments.Add(document);
        _context.SaveChanges();

        return true;
    }

    public bool UpdatePatientDocument(PatientDocument document)
    {
        _context.PatientDocuments.Update(document);
        _context.SaveChanges();

        return true;
    }

    public bool DeletePatientDocumentById(long id)
    {
        var document = _context.PatientDocuments.Find(id);

        if (document == null)
        {
            return false;
        }

        _context.PatientDocuments.Remove(document);
        _context.SaveChanges();

        return true;
    }
}