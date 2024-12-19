using System.Net.Http.Json;
using System.Text.Json;
using FvckAds.Client.Application.WebClient.ApiClients;
using FvckAds.Infrastructure.ApiClients.Requests;

namespace FvckAds.Infrastructure.ApiClients;

public class UserManagerApiClient(IHttpClientFactory httpClientFactory) : IUserManagerApi
{
    public async Task<string?> GetTokenAsync(Guid apiKey, CancellationToken cancellationToken = default)
    {
        using var client = httpClientFactory.CreateClient("UserManagerApi");
        
        var command = new GetTokenRequest() { ApiKey = apiKey };
        
        var response = await client.PostAsJsonAsync("/authentications", command, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        
        var responseStringData = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return responseStringData;
    }
}