using FvckAds.Domain.Users;

namespace FvckAds.Domain.Rooms;

public class RoomUser : BaseEntity
{
    public int RoomId { get; set; }
    public Room? Room { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public string? ConnectionId { get; set; }
}
