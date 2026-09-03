namespace SampleProject.Models;

public class Address
{
    public long Id { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public int CountryId { get; set; }

    public int StateId { get; set; }

    public int CityId { get; set; }

    public string PinCode { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public bool IsActive { get; set; }
}