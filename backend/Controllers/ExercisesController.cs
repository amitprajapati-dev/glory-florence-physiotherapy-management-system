using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExercisesController : ControllerBase
{
    private readonly IExercise _exercise;

    public ExercisesController(IExercise exercise)
    {
        _exercise = exercise;
    }

    [HttpGet]
    public IActionResult GetAllExercise()
    {
        return Ok(_exercise.GetAllExercise());
    }

    [HttpGet("{id}")]
    public IActionResult GetExerciseById(long id)
    {
        var exercise = _exercise.GetExerciseById(id);

        if (exercise == null)
        {
            return NotFound();
        }

        return Ok(exercise);
    }

    [HttpPost]
    public IActionResult AddExercise([FromBody] Exercise exercise)
    {
        return Ok(_exercise.AddExercise(exercise));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateExercise(
        long id,
        [FromBody] Exercise exercise)
    {
        exercise.Id = id;

        return Ok(_exercise.UpdateExercise(exercise));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteExerciseById(long id)
    {
        var result = _exercise.DeleteExerciseById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}