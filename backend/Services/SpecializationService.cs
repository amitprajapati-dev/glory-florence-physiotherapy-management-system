using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class SpecializationService : ISpecialization
{
    private readonly AppDbContext _context;

    public SpecializationService(AppDbContext context)
    {
        _context = context;
    }

    public List<Specialization> GetAllSpecialization()
    {
        return _context.Specializations.ToList();
    }

    public Specialization? GetSpecializationById(int id)
    {
        return _context.Specializations.Find(id);
    }

    public bool AddSpecialization(Specialization specialization)
    {
        _context.Specializations.Add(specialization);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateSpecialization(Specialization specialization)
    {
        _context.Specializations.Update(specialization);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteSpecializationById(int id)
    {
        var specialization = _context.Specializations.Find(id);

        if (specialization == null)
        {
            return false;
        }

        _context.Specializations.Remove(specialization);
        _context.SaveChanges();

        return true;
    }
}