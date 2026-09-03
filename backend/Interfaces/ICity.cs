using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface ICity
{
    List<City> GetAllCity();

    City? GetCityById(int id);

    bool AddCity(City city);

    bool UpdateCity(City city);

    bool DeleteCityById(int id);
}