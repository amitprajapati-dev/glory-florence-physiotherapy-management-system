using SampleProject.Models;

namespace SampleProject.Interfaces;

public interface IAddress
{
    List<Address> GetAllAddress();

    Address? GetAddressById(long id);

    bool AddAddress(Address address);

    bool UpdateAddress(Address address);

    bool DeleteAddressById(long id);
}