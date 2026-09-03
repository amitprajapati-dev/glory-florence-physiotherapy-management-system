using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface ITreatmentType
{
    List<TreatmentType> GetAllTreatmentType();

    TreatmentType? GetTreatmentTypeById(int id);

    bool AddTreatmentType(TreatmentType treatmentType);

    bool UpdateTreatmentType(TreatmentType treatmentType);

    bool DeleteTreatmentTypeById(int id);
}