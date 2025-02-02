using MediatR;

namespace FvckAds.Client.Application.WebClient.Authentications.Commands;

public class GetJwtTokenCommand : IRequest<string?>
{
    public Guid ApiKey { get; set; }
}