namespace SampleProject.Models;

public class UserProfile
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public int GenderId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string ProfileImage { get; set; }

    public string PhoneNumber { get; set; }

    public long AddressId { get; set; }

    public string EmergencyContactName { get; set; }

    public string EmergencyContactPhone { get; set; }

    public int BloodGroupId { get; set; }

    public string Occupation { get; set; }

    public DateTime RegistrationDate { get; set; }
}