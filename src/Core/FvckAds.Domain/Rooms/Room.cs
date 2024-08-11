using FvckAds.Domain.Users;

namespace FvckAds.Domain.Rooms;

public class Room : BaseEntity
{
    public required string Name { get; set; }
    public required List<RoomUser> RoomUsers { get; set; }
}