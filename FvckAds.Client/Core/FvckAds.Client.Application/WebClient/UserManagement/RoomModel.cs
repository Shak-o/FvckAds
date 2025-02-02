namespace FvckAds.Client.Application.WebClient.UserManagement;

public class RoomModel
{
    public required string RoomName { get; set; }
    public List<string>? ThreadNames { get; set; }
    public required Guid Identifier { get; set; }
}