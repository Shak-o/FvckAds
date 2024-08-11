using FvckAds.Domain.Users;

namespace FvckAds.Domain.Rooms;

public class RoomUser
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public required Room Room { get; set; }
    public int UserId { get; set; }
    public required User User { get; set; }
    public required string ConnectionId { get; set; }
}
