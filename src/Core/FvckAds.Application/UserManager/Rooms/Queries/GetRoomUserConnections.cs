using MediatR;

namespace FvckAds.Application.UserManager.Rooms.Queries;

public class GetRoomUserConnections : IRequest<string[]>
{
    public Guid RoomId { get; set; }
}