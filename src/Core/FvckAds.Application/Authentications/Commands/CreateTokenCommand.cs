using MediatR;

namespace FvckAds.Application.Authentications.Commands;

public class CreateTokenCommand : IRequest<string>
{
    public required Guid ApiKey { get; set; }
}