using FvckAds.Domain.Users;

namespace FvckAds.Domain.Rooms;

public class Room : BaseEntity
{
    public required string Name { get; set; }
    public Guid UniqueIdentifier { get; set; }
    public List<RoomUser> RoomUsers { get; set; }
}