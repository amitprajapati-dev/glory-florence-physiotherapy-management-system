using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface ICountry
{
    List<Country> GetAllCountry();

    Country? GetCountryById(int id);

    bool AddCountry(Country country);

    bool UpdateCountry(Country country);

    bool DeleteCountryById(int id);
}