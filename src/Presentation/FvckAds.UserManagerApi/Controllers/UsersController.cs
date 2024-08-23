using FvckAds.Application.Rooms.Commands;
using FvckAds.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FvckAds.UserManagerApi.Controllers;

[ApiController]
[Route("[controller]")]
// TODO Auth
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public Task CreateUser(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
        => mediator.Send(createUserCommand, cancellationToken);
}