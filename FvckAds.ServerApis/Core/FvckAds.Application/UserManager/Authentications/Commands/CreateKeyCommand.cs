using MediatR;

namespace FvckAds.Application.UserManager.Authentications.Commands;

public class CreateKeyCommand : IRequest<Guid>
{
    public required string Client { get; set; }
    public required string Secret { get; set; }
    public int UserId { get; set; }
}