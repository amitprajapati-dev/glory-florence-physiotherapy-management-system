using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class CountryService : ICountry
{
    private readonly AppDbContext _context;

    public CountryService(AppDbContext context)
    {
        _context = context;
    }

    public List<Country> GetAllCountry()
    {
        return _context.Countries.ToList();
    }

    public Country? GetCountryById(int id)
    {
        return _context.Countries.Find(id);
    }

    public bool AddCountry(Country country)
    {
        _context.Countries.Add(country);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateCountry(Country country)
    {
        _context.Countries.Update(country);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteCountryById(int id)
    {
        var country = _context.Countries.Find(id);

        if (country == null)
        {
            return false;
        }

        _context.Countries.Remove(country);
        _context.SaveChanges();

        return true;
    }
}