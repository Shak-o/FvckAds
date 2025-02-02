using MediatR;

namespace FvckAds.Client.Application.WebClient.UserManagement;

public class GetRoomsQuery : IRequest<List<RoomModel>>
{
    public required string Token { get; set; }
}