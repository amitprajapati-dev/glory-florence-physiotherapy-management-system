using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IRole
{
    List<Role> GetAllRole();

    Role? GetRoleById(int id);

    bool AddRole(Role role);

    bool UpdateRole(Role role);

    bool DeleteRoleById(int id);
}