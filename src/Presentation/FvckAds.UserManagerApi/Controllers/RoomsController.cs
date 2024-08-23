using FvckAds.Application.Rooms.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FvckAds.UserManagerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomsController(IMediator mediator)  : ControllerBase
{
    [HttpPost]
    public Task<Guid> CreateRoom(CreateRoomCommand createRoomCommand, CancellationToken cancellationToken)
        => mediator.Send(createRoomCommand, cancellationToken);
}