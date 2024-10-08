﻿using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Domain.Rooms;
using Microsoft.EntityFrameworkCore;

namespace FvckAds.Persistence.Repositories;

public class RoomRepository (ChatDbContext context) : IRoomRepository
{
    public async Task<string?[]> GetRoomConnectionsAsync(Guid roomId, CancellationToken cancellationToken)
    {
        var room = await context.Rooms.FirstAsync(x => x.UniqueIdentifier == roomId, cancellationToken);
        var connections = await context.RoomUsers.AsNoTracking().Where(r => r.RoomId == room.Id).Select(x => x.ConnectionId)
            .ToArrayAsync(cancellationToken);

        return connections;
    }

    public async Task AddConnectionToRoom(string tag, Guid roomId, string connectionId, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstAsync(x => x.Tag == tag, cancellationToken);
        var room = await context.Rooms.FirstAsync(x => x.UniqueIdentifier == roomId, cancellationToken);
        
        var existingConnection = await context.RoomUsers.FirstOrDefaultAsync(x => x.UserId == user.Id && x.RoomId == room.Id, cancellationToken);
        if (existingConnection != null)
        {
            existingConnection.ConnectionId = connectionId;
            await context.SaveChangesAsync(cancellationToken);
            return;
        }
        
        var roomUser = new RoomUser() { Room = room, User = user , ConnectionId = connectionId};
        context.RoomUsers.Add(roomUser);
        await context.SaveChangesAsync(cancellationToken);
    }
}