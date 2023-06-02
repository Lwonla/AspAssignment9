using System.Diagnostics;
using WebApp.Helpers.Repositories;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Services;

public class AddressService
{
    private readonly AddressRepository _addressRepository;
    private readonly UserAddressRepository _userAddressRepository;

    public AddressService(AddressRepository addressRepository, UserAddressRepository userAddressRepository)
    {
        _addressRepository = addressRepository;
        _userAddressRepository = userAddressRepository;
    }

    public async Task<AddressEntity> GetOrCreateAsync(AddressEntity entity)
    {
        var _entity = await _addressRepository.GetAsync(u => u.StreetName == entity.StreetName && u.PostalCode == entity.PostalCode && u.City == entity.City);
        _entity ??= await _addressRepository.AddAsync(entity);

        return _entity;

    }
    public async Task<bool> AddUserAddress(string userId, int AddressID)
    {
        try
        {
            var entity = await _userAddressRepository.AddAsync(new UserAddressEntity
            {
            UserId = userId,
            AddressId = AddressID
            });
            if (entity != null)
                return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
  