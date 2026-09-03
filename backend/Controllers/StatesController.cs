using Microsoft.AspNetCore.Mvc;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatesController : ControllerBase
{
    private readonly IState _state;

    public StatesController(IState state)
    {
        _state = state;
    }

    [HttpGet]
    public IActionResult GetAllState()
    {
        return Ok(_state.GetAllState());
    }

    [HttpGet("{id}")]
    public IActionResult GetStateById(int id)
    {
        var state = _state.GetStateById(id);

        if (state == null)
        {
            return NotFound();
        }

        return Ok(state);
    }

    [HttpPost]
    public IActionResult AddState([FromBody] State state)
    {
        return Ok(_state.AddState(state));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateState(
        int id,
        [FromBody] State state)
    {
        state.Id = id;

        return Ok(_state.UpdateState(state));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStateById(int id)
    {
        var result = _state.DeleteStateById(id);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}