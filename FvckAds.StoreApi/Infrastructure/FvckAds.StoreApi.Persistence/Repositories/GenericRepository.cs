using System.Linq.Expressions;
using FvckAds.StoreApi.Application.Interfaces;
using FvckAds.StoreApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace FvckAds.StoreApi.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly StoreDbContext _context;

    public GenericRepository(StoreDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddEntityAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

    public Task AddEntitiesAsync(T[] entities, CancellationToken cancellationToken)
    {
        var dbSet = _context.Set<T>();
        dbSet.AddRange(entities);
        return _context.SaveChangesAsync(cancellationToken);
    }

    public Task RemoveEntityAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Remove(entity);
        return _context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveEntityAsync<TE>(int id, CancellationToken cancellationToken) where TE : BaseEntity
    {
        var dbSet = _context.Set<T>();
        await dbSet.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateEntityAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Remove(entity);
        return _context.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateEntityAsync<TE>(int id, CancellationToken cancellationToken) where TE : BaseEntity
    {
        var transaction = _context.Database.BeginTransaction();
        throw new NotImplementedException();
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
    {
        return _context.Set<T>().Where(filter).FirstAsync(cancellationToken: cancellationToken);
    }

    public Task<TResult> GetAsync<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> projection, CancellationToken cancellationToken)
    {
        return _context.Set<T>().Where(filter)
            .AsNoTracking()
            .Select(projection)
            .FirstAsync(cancellationToken: cancellationToken);
    }

    public T GetFirst()
    {
        return _context.Set<T>().First();
    }
    
    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken)
    {
        return _context.Set<T>().FirstOrDefaultAsync(filter, cancellationToken);
    }
}