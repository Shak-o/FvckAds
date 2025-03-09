using MediatR;

namespace FvckAds.StoreApi.Application.Messages.Commands;

public class StoreMessageCommand : IRequest
{
    public Guid RoomId { get; set; }
    public Guid ThreadId { get; set; }
    public required string Tag { get; set; }
    public required string Content { get; set; } 
}