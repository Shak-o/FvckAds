using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using FvckAds.Client.Application.WebClient.ApiClients;
using FvckAds.Client.Application.WebClient.UserManagement;
using FvckAds.Infrastructure.ApiClients.Requests;

namespace FvckAds.Infrastructure.ApiClients;

public class UserManagerApiClient(IHttpClientFactory httpClientFactory) : IUserManagerApi
{
    public string JwtToken { get; set; }

    private static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions()
        { PropertyNameCaseInsensitive = true };
    public async Task<string?> GetTokenAsync(Guid apiKey, CancellationToken cancellationToken = default)
    {
        using var client = httpClientFactory.CreateClient("UserManagerApi");
        
        var command = new GetTokenRequest() { ApiKey = apiKey };
        
        var response = await client.PostAsJsonAsync("/authentications", command, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        
        var responseStringData = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        return responseStringData;
    }

    public async Task<List<RoomModel>?> GetRoomsAsync(CancellationToken cancellationToken = default)
    {
        using var client = httpClientFactory.CreateClient("UserManagerApi");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtToken);
        var response = await client.GetAsync("/rooms", cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();
        
        using var responseStringData = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        var convert = await JsonSerializer.DeserializeAsync<List<RoomModel>>(responseStringData, _jsonSerializerOptions,cancellationToken: cancellationToken);
        return convert;
    }
}