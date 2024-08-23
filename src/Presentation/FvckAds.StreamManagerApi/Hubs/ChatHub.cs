using FvckAds.Application.Rooms.Commands;
using FvckAds.Application.Rooms.Queries;
using FvckAds.StreamManagerApi.Interfaces;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace FvckAds.StreamManagerApi.Hubs;

public class ChatHub(IMediator mediator) : Hub<IChatClient>
{
    public override async Task OnConnectedAsync()
    {
        var context = Context.GetHttpContext();
        if (context == null)
            throw new ApplicationException("Context is null");
        
        var tag = context.Request.Query.First(x => x.Key == "tag").Value.First();
        var roomId = context.Request.Query.First(x => x.Key == "roomId").Value.First();
        if (tag == null || roomId == null)
            throw new ApplicationException("Tag is null");
        
        var canParse = Guid.TryParse(roomId, out var roomIdParsed);
        var connectionId = Context.ConnectionId;
        await mediator.Send(new AddConnectionToRoomCommand
        {
            Tag = tag,
            RoomId = roomIdParsed,
            ConnectionId = connectionId
        });
        
        await base.OnConnectedAsync();
    }

    public async Task SendMessage(string tag, string message, Guid identifier)
    {
        var connectionIds = await mediator.Send(new GetRoomUserConnections() { RoomId = identifier });
        await Clients.Clients(connectionIds).ReceiveMessage(tag, message, identifier);
    }
}