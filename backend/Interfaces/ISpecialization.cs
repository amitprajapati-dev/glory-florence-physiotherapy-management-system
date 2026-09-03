using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface ISpecialization
{
    List<Specialization> GetAllSpecialization();

    Specialization? GetSpecializationById(int id);

    bool AddSpecialization(Specialization specialization);

    bool UpdateSpecialization(Specialization specialization);

    bool DeleteSpecializationById(int id);
}