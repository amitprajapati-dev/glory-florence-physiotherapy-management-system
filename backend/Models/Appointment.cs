namespace SampleProject.Models;

public class Appointment
{
    public long Id { get; set; }

    public long PatientId { get; set; }

    public long PhysiotherapistId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public int AppointmentTypeId { get; set; }

    public int StatusId { get; set; }

    public string Reason { get; set; }

    public string Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}