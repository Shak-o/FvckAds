using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Domain;
using Microsoft.EntityFrameworkCore;

namespace FvckAds.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ChatDbContext _context;

    public GenericRepository(ChatDbContext context)
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
}