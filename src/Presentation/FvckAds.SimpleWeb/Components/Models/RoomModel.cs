namespace FvckAds.SimpleWeb.Components.Models;

public class RoomModel
{
    public required string Name { get; set; }
    public List<string>? ThreadNames { get; set; }
    public required Guid UniqueId { get; set; }
}