using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface ITreatmentPlan
{
    List<TreatmentPlan> GetAllTreatmentPlans();

    TreatmentPlan? GetTreatmentPlanById(long id);

    bool AddTreatmentPlan(TreatmentPlan treatmentPlan);

    bool UpdateTreatmentPlan(TreatmentPlan treatmentPlan);

    bool DeleteTreatmentPlanById(long id);
}