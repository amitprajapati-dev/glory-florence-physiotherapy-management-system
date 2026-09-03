namespace SampleProject.Models;

public class TreatmentPlan
{
    public long Id { get; set; }

    public long PatientId { get; set; }

    public long PhysiotherapistId { get; set; }

    public long AssessmentId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime ExpectedEndDate { get; set; }

    public int NumberOfSessions { get; set; }

    public string Goal { get; set; }

    public string Notes { get; set; }

    public int StatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}