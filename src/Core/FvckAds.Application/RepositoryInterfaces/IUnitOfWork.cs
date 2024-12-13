namespace FvckAds.Application.RepositoryInterfaces;

public interface IUnitOfWork
{
    public Task<int> SaveAsync(CancellationToken cancellationToken = default);
}