using FvckAds.Domain.Rooms;

namespace FvckAds.Domain.Users;

public class User : BaseEntity
{
    public required string Tag { get; set; }
    public required string Title { get; set; }
    public List<RoomUser> RoomUsers { get; set; }
}