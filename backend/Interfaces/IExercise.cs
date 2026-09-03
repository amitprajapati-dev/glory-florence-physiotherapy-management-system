using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IExercise
{
    List<Exercise> GetAllExercise();

    Exercise? GetExerciseById(long id);

    bool AddExercise(Exercise exercise);

    bool UpdateExercise(Exercise exercise);

    bool DeleteExerciseById(long id);
}