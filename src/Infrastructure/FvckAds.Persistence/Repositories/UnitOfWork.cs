using FvckAds.Application.RepositoryInterfaces;

namespace FvckAds.Persistence.Repositories;

public class UnitOfWork(ChatDbContext context) : IUnitOfWork
{
    public Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}