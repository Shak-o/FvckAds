using FvckAds.Application.UserManager.Authentications.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FvckAds.UserManagerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<string> GetTokenAsync([FromBody]CreateTokenCommand request, CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }

    [HttpPost("key")]
    [AllowAnonymous]
    public async Task<Guid> CreateKeyAsync(CreateKeyCommand request, CancellationToken cancellationToken)
    {
        return await mediator.Send(request, cancellationToken);
    }
}