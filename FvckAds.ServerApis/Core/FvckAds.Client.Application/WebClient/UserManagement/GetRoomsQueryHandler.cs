using FvckAds.Client.Application.WebClient.ApiClients;
using MediatR;

namespace FvckAds.Client.Application.WebClient.UserManagement;

public class GetRoomsQueryHandler(IUserManagerApi userManagerApi) : IRequestHandler<GetRoomsQuery, List<RoomModel>?>
{
    public async Task<List<RoomModel>?> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
    {
        userManagerApi.JwtToken = request.Token;
        var res = await userManagerApi.GetRoomsAsync(cancellationToken);
        res.ForEach(x => x.ThreadNames = []); // TODO why not stupid bastard
        return res;
    }
}