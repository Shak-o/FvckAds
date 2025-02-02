using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Domain.Auth;
using Microsoft.EntityFrameworkCore;

namespace FvckAds.Persistence.Repositories;

public class AuthKeyRepository(ChatDbContext chatDbContext) : IAuthKeyRepository
{
    public Task<AuthKey?> GetAuthKeyByIdAsync(Guid authKeyId)
    {
        return chatDbContext.AuthKeys.Include(x => x.User).FirstOrDefaultAsync(x => x.Key == authKeyId);
    }
}