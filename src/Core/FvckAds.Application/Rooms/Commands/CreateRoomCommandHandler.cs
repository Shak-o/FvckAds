using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Domain.Rooms;
using MediatR;

namespace FvckAds.Application.Rooms.Commands;

public class CreateRoomCommandHandler(IUsersRepository usersRepository, IGenericRepository<Room> roomRepository, IGenericRepository<RoomUser> roomUserRepository) : IRequestHandler<CreateRoomCommand, Guid>
{
    public async Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        // TODO add transaction
        var guid = Guid.NewGuid();
        var now = DateTime.Now.ToUniversalTime();
        var roomId = await roomRepository.AddEntityAsync(new Room
        {
            CreateDate = now,
            Name = request.RoomName,
            UniqueIdentifier = guid
        }, cancellationToken);
        var userIds = await usersRepository.GetUserIdsByTagsAsync(request.Tags, cancellationToken);
        var roomUsersToAdd = new RoomUser[userIds.Length];

        for (var i = 0; i < userIds.Length; i++)
        {
            roomUsersToAdd[i] = new RoomUser
            {
                CreateDate = now,
                RoomId = roomId,
                UserId = userIds[i]
            };
        }

        await roomUserRepository.AddEntitiesAsync(roomUsersToAdd, cancellationToken);

        return guid;
    }
}