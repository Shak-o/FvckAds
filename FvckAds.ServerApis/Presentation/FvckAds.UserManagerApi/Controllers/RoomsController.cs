using FvckAds.Application.UserManager.Rooms.Commands;
using FvckAds.Application.UserManager.Rooms.Models;
using FvckAds.Application.UserManager.Rooms.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FvckAds.UserManagerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomsController(IMediator mediator)  : ControllerBase
{
    [HttpPost]
    public Task<Guid> CreateRoom(CreateRoomCommand createRoomCommand, CancellationToken cancellationToken)
        => mediator.Send(createRoomCommand, cancellationToken);

    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IEnumerable<RoomReturnModel>> GetAllRooms(CancellationToken cancellationToken)
    {
        var tag = HttpContext.User.Identity?.Name;
        if (string.IsNullOrEmpty(tag))
            throw new Exception("Unauthorized"); // TODO fix exception tipe
        var query = new GetRoomsQuery() {Tag = tag};
        return await mediator.Send(query, cancellationToken);
    }
}