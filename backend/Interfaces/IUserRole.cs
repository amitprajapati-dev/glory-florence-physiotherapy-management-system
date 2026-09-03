using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IUserRole
{
    List<UserRole> GetAllUserRole();

    UserRole? GetUserRoleById(long id);

    bool AddUserRole(UserRole userRole);

    bool UpdateUserRole(UserRole userRole);

    bool DeleteUserRoleById(long id);
}