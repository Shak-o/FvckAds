using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Application.UserManager.Rooms.Models;
using MediatR;

namespace FvckAds.Application.UserManager.Rooms.Queries;

public class GetRoomsQueryHandler(IUsersRepository usersRepository) : IRequestHandler<GetRoomsQuery, List<RoomReturnModel>>
{
    public async Task<List<RoomReturnModel>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await usersRepository.GetUserRoomsAsync(request.Tag, cancellationToken);
        var convert = rooms.Select(x => new RoomReturnModel
        {
            RoomName = x.Name,
            Identifier = x.UniqueIdentifier
        }).ToList();
        return convert;
    }
}