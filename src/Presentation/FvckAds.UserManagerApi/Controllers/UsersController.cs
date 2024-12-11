using FvckAds.Application.Authentications.Commands;
using FvckAds.Application.Rooms.Commands;
using FvckAds.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FvckAds.UserManagerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IMediator mediator) : ControllerBase
{
    // No auth, require specific custom token. 
    [HttpPost]
    [Authorize]
    public Task CreateUser(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
        => mediator.Send(createUserCommand, cancellationToken);

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<string> GetTokenAsync()
    {
        return await mediator.Send(new CreateTokenCommand());
    }
}