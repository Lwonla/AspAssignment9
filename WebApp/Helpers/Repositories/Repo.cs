using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using WebApp.Contexts;

namespace WebApp.Helpers.Repositories;

public abstract class Repo<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected Repo(DataContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


    //public async Task<TEntity> UpdateAsync(TEntity entity)
    ////public async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression)
    //{
    //    try
    //    {
    //        //var _entity = _context.Set<TEntity>().FirstOrDefaultAsync(expression);
    //        _context.Set<TEntity>().Update(entity);
    //        await _context.SaveChangesAsync();
    //        return entity;
    //    }
    //    catch (Exception ex) { Debug.WriteLine(ex.Message); }
    //    return null!;
    //}

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var _entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);

            if (_entity != null)
            {
                return _entity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAsync()
    {
        try
        {
            var _entities= await _context.Set<TEntity>().ToListAsync();

            if (_entities != null)
            {
                return _entities;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

}
