namespace SampleProject.Models;

public class User
{
    public long Id { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }
}