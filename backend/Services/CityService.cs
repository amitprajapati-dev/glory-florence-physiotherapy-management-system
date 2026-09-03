using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class CityService : ICity
{
    private readonly AppDbContext _context;

    public CityService(AppDbContext context)
    {
        _context = context;
    }

    public List<City> GetAllCity()
    {
        return _context.Cities.ToList();
    }

    public City? GetCityById(int id)
    {
        return _context.Cities.Find(id);
    }

    public bool AddCity(City city)
    {
        _context.Cities.Add(city);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateCity(City city)
    {
        _context.Cities.Update(city);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteCityById(int id)
    {
        var city = _context.Cities.Find(id);

        if (city == null)
        {
            return false;
        }

        _context.Cities.Remove(city);
        _context.SaveChanges();

        return true;
    }
}