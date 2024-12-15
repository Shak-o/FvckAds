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
    [HttpPost]
    public Task CreateUser(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
        => mediator.Send(createUserCommand, cancellationToken);

   
}