using MediatR;

namespace FvckAds.Application.UserManager.Users.Commands;

public class CreateUserCommand : IRequest<int>
{
    public required string Tag { get; set; }
}