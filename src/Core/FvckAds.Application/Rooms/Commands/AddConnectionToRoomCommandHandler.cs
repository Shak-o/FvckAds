using FvckAds.Application.RepositoryInterfaces;
using MediatR;

namespace FvckAds.Application.Rooms.Commands;

public class AddConnectionToRoomCommandHandler(IRoomRepository roomRepository) : IRequestHandler<AddConnectionToRoomCommand>
{
    public async Task Handle(AddConnectionToRoomCommand request, CancellationToken cancellationToken)
    {
        await roomRepository.AddConnectionToRoom(request.Tag, request.RoomId, request.ConnectionId, cancellationToken);
    }
}