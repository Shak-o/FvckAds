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
        if (tag == null)
            throw new ApplicationException("Tag is null");
        
        var connectionId = Context.ConnectionId;
        await mediator.Send(new AddConnectionToRoomCommand
        {
            Tag = tag,
            ConnectionId = connectionId
        });
        
        await base.OnConnectedAsync();
    }

    public async Task SendMessage(int roomId, string message)
    {
        var connectionIds = await mediator.Send(new GetRoomUserConnections() { RoomId = roomId });
        await Clients.Clients(connectionIds).ReceiveMessage(roomId, message);
    }
}