namespace SampleProject.Models;

public class City
{
    public int Id { get; set; }

    public int StateId { get; set; }

    public string Name { get; set; }

    public string PinCode { get; set; }

    public bool IsActive { get; set; }
}