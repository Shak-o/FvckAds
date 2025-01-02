using FvckAds.Application.UserManager.Rooms.Models;
using MediatR;

namespace FvckAds.Application.UserManager.Rooms.Queries;

public class GetRoomsQuery : IRequest<List<RoomReturnModel>>
{
    public required string Tag { get; set; }   
}