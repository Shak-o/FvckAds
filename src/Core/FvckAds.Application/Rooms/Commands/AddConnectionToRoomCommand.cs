using MediatR;

namespace FvckAds.Application.Rooms.Commands;

public class AddConnectionToRoomCommand : IRequest
{
    public required string Tag { get; set; }
    public Guid RoomId { get; set; }
    public required string ConnectionId { get; set; }
}