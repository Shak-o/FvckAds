using FvckAds.Client.Application.WebClient.UserManagement;

namespace FvckAds.Client.Application.WebClient.ApiClients;

public interface IUserManagerApi
{
    string JwtToken { get; set; }
    Task<string?> GetTokenAsync(Guid apiKey, CancellationToken cancellationToken = default);
    Task<List<RoomModel>?> GetRoomsAsync(CancellationToken cancellationToken = default);
}