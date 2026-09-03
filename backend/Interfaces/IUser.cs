using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IUser
{
    List<User> GetAllUser();

    User? GetUserById(int id);

    bool AddUser(User user);

    bool UpdateUser(User user);

    bool DeleteUserById(int id);
}