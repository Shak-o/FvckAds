using MediatR;

namespace FvckAds.Application.Users.Commands;

public class CreateUserCommand : IRequest<int>
{
    public required string Tag { get; set; }
    public required Guid AllowToken { get; set; } // TODO Validate this in db
}