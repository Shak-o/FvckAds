namespace FvckAds.Application.RepositoryInterfaces;

public interface IRoomRepository
{
    Task<string?[]> GetRoomConnectionsAsync(Guid roomId, CancellationToken cancellationToken);
    Task AddConnectionToRoom(string tag, Guid roomId, string connectionId, CancellationToken cancellationToken);
}