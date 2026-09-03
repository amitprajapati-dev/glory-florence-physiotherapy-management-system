using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class RoleService : IRole
{
    private readonly AppDbContext _context;

    public RoleService(AppDbContext context)
    {
        _context = context;
    }

    public List<Role> GetAllRole()
    {
        return _context.Roles.ToList();
    }

    public Role? GetRoleById(int id)
    {
        return _context.Roles.Find(id);
    }

    public bool AddRole(Role role)
    {
        _context.Roles.Add(role);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateRole(Role role)
    {
        _context.Roles.Update(role);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteRoleById(int id)
    {
        var role = _context.Roles.Find(id);

        if (role == null)
        {
            return false;
        }

        _context.Roles.Remove(role);
        _context.SaveChanges();

        return true;
    }
}