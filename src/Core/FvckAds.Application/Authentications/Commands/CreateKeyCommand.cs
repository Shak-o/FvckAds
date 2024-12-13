using MediatR;

namespace FvckAds.Application.Authentications.Commands;

public class CreateKeyCommand : IRequest<Guid>
{
    public required string Client { get; set; }
    public required string Secret { get; set; }
}