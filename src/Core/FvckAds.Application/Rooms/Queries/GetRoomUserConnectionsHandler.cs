using FvckAds.Application.RepositoryInterfaces;
using MediatR;

namespace FvckAds.Application.Rooms.Queries;

public class GetRoomUserConnectionsHandler(IRoomRepository roomRepository) : IRequestHandler<GetRoomUserConnections, string[]>
{
    public async Task<string[]> Handle(GetRoomUserConnections request, CancellationToken cancellationToken)
    {
        var connections = await roomRepository.GetRoomConnectionsAsync(request.RoomId, cancellationToken);
        return connections;
    }
}