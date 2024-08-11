using FvckAds.Domain;

namespace FvckAds.Application.RepositoryInterfaces;

public interface IGenericRepository<in T> where T : BaseEntity
{
    Task<int> AddEntityAsync(T entity, CancellationToken cancellationToken);
    Task AddEntitiesAsync(T[] entities, CancellationToken cancellationToken);
    Task RemoveEntityAsync(T entity, CancellationToken cancellationToken);
    Task RemoveEntityAsync<TE>(int id, CancellationToken cancellationToken) where TE : BaseEntity;
    Task UpdateEntityAsync(T entity, CancellationToken cancellationToken);
    Task UpdateEntityAsync<TE>(int id, CancellationToken cancellationToken) where TE : BaseEntity;
}