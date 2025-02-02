using FvckAds.Domain.Rooms;

namespace FvckAds.Application.RepositoryInterfaces;

public interface IUsersRepository
{
    Task<int[]> GetUserIdsByTagsAsync(List<string> tags, CancellationToken cancellationToken);
    Task<List<Room>> GetUserRoomsAsync(string userTag, CancellationToken cancellationToken);
}