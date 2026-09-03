using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IState
{
    List<State> GetAllState();

    State? GetStateById(int id);

    bool AddState(State state);

    bool UpdateState(State state);

    bool DeleteStateById(int id);
}