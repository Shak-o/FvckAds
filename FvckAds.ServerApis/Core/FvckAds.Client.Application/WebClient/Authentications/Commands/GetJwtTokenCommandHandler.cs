using FvckAds.Client.Application.WebClient.ApiClients;
using MediatR;

namespace FvckAds.Client.Application.WebClient.Authentications.Commands;

public class GetJwtTokenCommandHandler(IUserManagerApi userManagerApi) : IRequestHandler<GetJwtTokenCommand, string?>
{
    public Task<string?> Handle(GetJwtTokenCommand request, CancellationToken cancellationToken)
    {
        return userManagerApi.GetTokenAsync(request.ApiKey, cancellationToken);
    }
}