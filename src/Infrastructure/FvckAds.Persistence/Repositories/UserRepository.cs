using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Domain.Rooms;
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

    public async Task<List<Room>> GetUserRoomsAsync(string userTag, CancellationToken cancellationToken)
    {
        var userId = await _context.Users.AsNoTracking().Where(x => x.Tag == userTag).Select(x => x.Id).FirstAsync(cancellationToken);
        return await _context.Rooms.Where(x => x.RoomUsers.Any(f => f.UserId == userId)).ToListAsync(cancellationToken);
    }
}