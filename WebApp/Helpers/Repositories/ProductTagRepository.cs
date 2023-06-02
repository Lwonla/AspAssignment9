using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories;

public class ProductTagRepository : Repo<ProductTagEntity>
{
    public ProductTagRepository(DataContext context) : base(context)
    {
    }
}
