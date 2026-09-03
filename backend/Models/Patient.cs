namespace SampleProject.Models;

public class Patient
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public string PatientNumber { get; set; }

    public long AddressId { get; set; }

    public DateTime RegistrationDate { get; set; }

    public string? ReferredBy { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}