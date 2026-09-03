namespace SampleProject.Models;

public class Exercise
{
    public long Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Instructions { get; set; }

    public string VideoUrl { get; set; }

    public string ImageUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}