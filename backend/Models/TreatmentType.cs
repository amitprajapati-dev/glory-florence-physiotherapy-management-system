namespace SampleProject.Models;

public class TreatmentType
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int DefaultDurationMinutes { get; set; }

    public decimal DefaultPrice { get; set; }

    public bool IsActive { get; set; }
}