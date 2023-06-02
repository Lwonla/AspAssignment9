using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Helpers.Repositories;

public class TagRepository : Repo<TagEntity>
{
    public TagRepository(DataContext context) : base(context)
    {
    }
}