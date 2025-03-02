using System.Diagnostics;
using System.Linq.Expressions;
using Data.context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _db = context.Set<TEntity>();

    public virtual async Task<TEntity?> CreateAsync(TEntity entity)
    { 
        ArgumentNullException.ThrowIfNull(entity);
        
        try
        {
            _db.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public virtual async Task<IEnumerable<TEntity>?> GetAllAsync()
    {
        try
        {
            var entities = await _db.ToListAsync();
            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
    
    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        { 
            var entity = await _db.FirstOrDefaultAsync(predicate);
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var exists = await _db.AnyAsync(predicate);
            return exists;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    
    public virtual async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        try
        {
            _db.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }


    public virtual async Task<bool> RemoveAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        try
        {
            _db.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
    
}