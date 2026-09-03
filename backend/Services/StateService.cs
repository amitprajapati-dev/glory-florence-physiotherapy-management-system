using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class StateService : IState
{
    private readonly AppDbContext _context;

    public StateService(AppDbContext context)
    {
        _context = context;
    }

    public List<State> GetAllState()
    {
        return _context.States.ToList();
    }

    public State? GetStateById(int id)
    {
        return _context.States.Find(id);
    }

    public bool AddState(State state)
    {
        _context.States.Add(state);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateState(State state)
    {
        _context.States.Update(state);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteStateById(int id)
    {
        var state = _context.States.Find(id);

        if (state == null)
        {
            return false;
        }

        _context.States.Remove(state);
        _context.SaveChanges();

        return true;
    }
}