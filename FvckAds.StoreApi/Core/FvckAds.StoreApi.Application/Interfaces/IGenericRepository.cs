using System.Linq.Expressions;
using FvckAds.StoreApi.Domain;

namespace FvckAds.StoreApi.Application.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<int> AddEntityAsync(T entity, CancellationToken cancellationToken);
    Task AddEntitiesAsync(T[] entities, CancellationToken cancellationToken);
    Task RemoveEntityAsync(T entity, CancellationToken cancellationToken);
    Task RemoveEntityAsync<TE>(int id, CancellationToken cancellationToken) where TE : BaseEntity;
    Task UpdateEntityAsync(T entity, CancellationToken cancellationToken);
    Task UpdateEntityAsync<TE>(int id, CancellationToken cancellationToken) where TE : BaseEntity;
    Task<T> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
    Task<TResult> GetAsync<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> projection, CancellationToken cancellationToken);
    T GetFirst();
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
}