using MediatR;

namespace FvckAds.Application.Rooms.Queries;

public class GetRoomUserConnections : IRequest<string[]>
{
    public int RoomId { get; set; }
}