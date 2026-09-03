using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class TreatmentTypeService : ITreatmentType
{
    private readonly AppDbContext _context;

    public TreatmentTypeService(AppDbContext context)
    {
        _context = context;
    }

    public List<TreatmentType> GetAllTreatmentType()
    {
        return _context.TreatmentTypes.ToList();
    }

    public TreatmentType? GetTreatmentTypeById(int id)
    {
        return _context.TreatmentTypes.Find(id);
    }

    public bool AddTreatmentType(TreatmentType treatmentType)
    {
        _context.TreatmentTypes.Add(treatmentType);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateTreatmentType(TreatmentType treatmentType)
    {
        _context.TreatmentTypes.Update(treatmentType);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteTreatmentTypeById(int id)
    {
        var treatmentType = _context.TreatmentTypes.Find(id);

        if (treatmentType == null)
        {
            return false;
        }

        _context.TreatmentTypes.Remove(treatmentType);
        _context.SaveChanges();

        return true;
    }
}