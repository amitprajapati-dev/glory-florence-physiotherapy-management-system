using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class UserProfileService : IUserProfile
{
    private readonly AppDbContext _context;

    public UserProfileService(AppDbContext context)
    {
        _context = context;
    }

    public List<UserProfile> GetAllUserProfile()
    {
        return _context.UserProfiles.ToList();
    }

    public UserProfile? GetUserProfileById(long id)
    {
        return _context.UserProfiles.Find(id);
    }

    public bool AddUserProfile(UserProfile userProfile)
    {
        _context.UserProfiles.Add(userProfile);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateUserProfile(UserProfile userProfile)
    {
        _context.UserProfiles.Update(userProfile);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteUserProfileById(long id)
    {
        var userProfile = _context.UserProfiles.Find(id);

        if (userProfile == null)
        {
            return false;
        }

        _context.UserProfiles.Remove(userProfile);
        _context.SaveChanges();

        return true;
    }
}