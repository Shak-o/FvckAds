using MediatR;

namespace FvckAds.Application.Users.Commands;

public class CreateUserCommand : IRequest<int>
{
    public required string Tag { get; set; }    
}