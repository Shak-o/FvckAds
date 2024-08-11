namespace FvckAds.Application.RepositoryInterfaces;

public interface IUsersRepository
{
    Task<int[]> GetUserIdsByTagsAsync(List<string> tags, CancellationToken cancellationToken);
}