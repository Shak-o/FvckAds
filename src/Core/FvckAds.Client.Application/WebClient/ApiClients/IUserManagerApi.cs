namespace FvckAds.Client.Application.WebClient.ApiClients;

public interface IUserManagerApi
{
    Task<string?> GetTokenAsync(Guid apiKey, CancellationToken cancellationToken = default); 
}