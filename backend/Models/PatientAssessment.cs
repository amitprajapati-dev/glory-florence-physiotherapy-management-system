namespace SampleProject.Models;

public class PatientAssessment
{
    public long Id { get; set; }

    public long PatientId { get; set; }

    public long? SessionId { get; set; }

    public long PhysiotherapistId { get; set; }

    public DateTime AssessmentDate { get; set; }

    public string ChiefComplaint { get; set; }

    public string CurrentCondition { get; set; }

    public int PainLevel { get; set; }

    public string Diagnosis { get; set; }

    public string ClinicalNotes { get; set; }

    public string Recommendations { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}