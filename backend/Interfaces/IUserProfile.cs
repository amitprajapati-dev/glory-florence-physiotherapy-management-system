using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IUserProfile
{
    List<UserProfile> GetAllUserProfile();

    UserProfile? GetUserProfileById(long id);

    bool AddUserProfile(UserProfile userProfile);

    bool UpdateUserProfile(UserProfile userProfile);

    bool DeleteUserProfileById(long id);
}