using MediatR;

namespace FvckAds.Application.UserManager.Authentications.Commands;

public class CreateTokenCommand : IRequest<string>
{
    public required Guid ApiKey { get; set; }
}