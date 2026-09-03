namespace SampleProject.Models;

public class PatientMedicalHistory
{
    public long Id { get; set; }

    public long PatientId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime DiagnosisDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}