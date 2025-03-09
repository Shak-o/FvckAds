namespace FvckAds.StoreApi.Domain.Messages;

public class Message
{
    public Guid RoomId { get; set; }
    public Guid ThreadId { get; set; }
    public required string Tag { get; set; }
    public required string Content { get; set; } // TODO: encrypt it.
}