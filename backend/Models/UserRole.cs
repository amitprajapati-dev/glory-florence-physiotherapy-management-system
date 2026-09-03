namespace SampleProject.Models;

public class UserRole
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public int RoleId { get; set; }

    public bool IsActive { get; set; }
}