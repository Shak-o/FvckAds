using MediatR;

namespace FvckAds.Application.Rooms.Queries;

public class GetRoomUserConnections : IRequest<string[]>
{
    public Guid RoomId { get; set; }
}