using SampleProject.Data;
using SampleProject.Interfaces;
using SampleProject.Models;

namespace SampleProject.Services;

public class AddressService : IAddress
{
    private readonly AppDbContext _context;

    public AddressService(AppDbContext context)
    {
        _context = context;
    }

    public List<Address> GetAllAddress()
    {
        return _context.Addresses.ToList();
    }

    public Address? GetAddressById(long id)
    {
        return _context.Addresses.Find(id);
    }

    public bool AddAddress(Address address)
    {
        _context.Addresses.Add(address);
        _context.SaveChanges();

        return true;
    }

    public bool UpdateAddress(Address address)
    {
        _context.Addresses.Update(address);
        _context.SaveChanges();

        return true;
    }

    public bool DeleteAddressById(long id)
    {
        var address = _context.Addresses.Find(id);

        if (address == null)
        {
            return false;
        }

        _context.Addresses.Remove(address);
        _context.SaveChanges();

        return true;
    }
}