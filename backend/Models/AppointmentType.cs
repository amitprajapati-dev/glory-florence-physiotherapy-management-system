namespace SampleProject.Models;

public class AppointmentType
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int DurationMinutes { get; set; }

    public bool IsActive { get; set; }
}