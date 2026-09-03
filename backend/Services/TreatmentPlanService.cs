using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class TreatmentPlanService : ITreatmentPlan
{
    private readonly AppDbContext _context;

    public TreatmentPlanService(AppDbContext context)
    {
        _context = context;
    }

    public List<TreatmentPlan> GetAllTreatmentPlans()
    {
        return _context.TreatmentPlans.ToList();
    }

    public TreatmentPlan? GetTreatmentPlanById(long id)
    {
        return _context.TreatmentPlans.Find(id);
    }

    public bool AddTreatmentPlan(TreatmentPlan treatmentPlan)
    {
        _context.TreatmentPlans.Add(treatmentPlan);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateTreatmentPlan(TreatmentPlan treatmentPlan)
    {
        _context.TreatmentPlans.Update(treatmentPlan);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteTreatmentPlanById(long id)
    {
        var treatmentPlan = _context.TreatmentPlans.Find(id);

        if (treatmentPlan == null)
        {
            return false;
        }

        _context.TreatmentPlans.Remove(treatmentPlan);
        _context.SaveChanges();

        return true;
    }
}