using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Domain.Rooms;
using Microsoft.EntityFrameworkCore;

namespace FvckAds.Persistence.Repositories;

public class RoomRepository (UserManagerDbContext context) : IRoomRepository
{
    public Task<string?[]> GetRoomConnectionsAsync(int roomId, CancellationToken cancellationToken)
    {
        return context.RoomUsers.AsNoTracking().Where(r => r.RoomId == roomId).Select(x => x.ConnectionId)
            .ToArrayAsync(cancellationToken);
    }

    public async Task AddConnectionToRoom(string tag, Guid roomId, string connectionId, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstAsync(x => x.Tag == tag, cancellationToken);
        var room = await context.Rooms.FirstAsync(x => x.UniqueIdentifier == roomId, cancellationToken);
        
        var roomUser = new RoomUser() { Room = room, User = user };
        context.RoomUsers.Add(roomUser);
        await context.SaveChangesAsync(cancellationToken);
    }
}