using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class ExerciseService : IExercise
{
    private readonly AppDbContext _context;

    public ExerciseService(AppDbContext context)
    {
        _context = context;
    }

    public List<Exercise> GetAllExercise()
    {
        return _context.Exercises.ToList();
    }

    public Exercise? GetExerciseById(long id)
    {
        return _context.Exercises.Find(id);
    }

    public bool AddExercise(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateExercise(Exercise exercise)
    {
        _context.Exercises.Update(exercise);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteExerciseById(long id)
    {
        var exercise = _context.Exercises.Find(id);

        if (exercise == null)
        {
            return false;
        }

        _context.Exercises.Remove(exercise);
        _context.SaveChanges();

        return true;
    }
}