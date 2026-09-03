using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class UserService : IUser
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public List<User> GetAllUser()
    {
        return _context.Users.ToList();
    }

    public User? GetUserById(int id)
    {
        return _context.Users.Find(id);
    }

    public bool AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteUserById(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return true;
    }
}