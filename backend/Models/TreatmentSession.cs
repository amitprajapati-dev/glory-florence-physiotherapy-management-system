namespace SampleProject.Models;

public class TreatmentSession
{
    public long Id { get; set; }

    public long AppointmentId { get; set; }

    public long PatientId { get; set; }

    public long PhysiotherapistId { get; set; }

    public long? TreatmentPlanId { get; set; }

    public DateTime SessionDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public int PainLevelBefore { get; set; }

    public int PainLevelAfter { get; set; }

    public string Notes { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}