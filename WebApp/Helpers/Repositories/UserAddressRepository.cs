using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories;

public class UserAddressRepository : Repo<UserAddressEntity>
{
    public UserAddressRepository(DataContext context) : base(context)
    {
    }
}