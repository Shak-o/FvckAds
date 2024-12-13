using FvckAds.Domain.Auth;

namespace FvckAds.Application.RepositoryInterfaces;

public interface IAuthKeyRepository
{
    Task<AuthKey?> GetAuthKeyByIdAsync(Guid authKeyId);
}