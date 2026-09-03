using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class UserRoleService : IUserRole
{
    private readonly AppDbContext _context;

    public UserRoleService(AppDbContext context)
    {
        _context = context;
    }

    public List<UserRole> GetAllUserRole()
    {
        return _context.UserRoles.ToList();
    }

    public UserRole? GetUserRoleById(long id)
    {
        return _context.UserRoles.Find(id);
    }

    public bool AddUserRole(UserRole userRole)
    {
        _context.UserRoles.Add(userRole);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateUserRole(UserRole userRole)
    {
        _context.UserRoles.Update(userRole);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteUserRoleById(long id)
    {
        var userRole = _context.UserRoles.Find(id);

        if (userRole == null)
        {
            return false;
        }

        _context.UserRoles.Remove(userRole);
        _context.SaveChanges();

        return true;
    }
}