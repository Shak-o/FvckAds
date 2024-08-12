namespace FvckAds.Application.RepositoryInterfaces;

public interface IRoomRepository
{
    Task<string?[]> GetRoomConnectionsAsync(int roomId, CancellationToken cancellationToken);
    Task AddConnectionToRoom(string tag, Guid roomId, string connectionId, CancellationToken cancellationToken);
}