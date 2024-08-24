using FvckAds.Application.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace FvckAds.Persistence.Repositories;

public class UserRepository : IUsersRepository
{
    private readonly ChatDbContext _context;

    public UserRepository(ChatDbContext context)
    {
        _context = context;
    }

    public Task<int[]> GetUserIdsByTagsAsync(List<string> tags, CancellationToken cancellationToken)
    {
        return _context.Users.Where(x => tags.Contains(x.Tag)).Select(x => x.Id).ToArrayAsync(cancellationToken);
    }
}