using FvckAds.Application.Authentications.Options;
using FvckAds.Application.Exceptions;
using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Domain.Auth;
using MediatR;
using Microsoft.Extensions.Options;

namespace FvckAds.Application.Authentications.Commands.Handlers;

public class CreateKeyCommandHandler(IOptions<JwtOptions> jwtOptions, IGenericRepository<AuthKey> authKeyRepo) : IRequestHandler<CreateKeyCommand, Guid>
{
    public async Task<Guid> Handle(CreateKeyCommand request, CancellationToken cancellationToken)
    {
        if (jwtOptions.Value.Client != request.Client || jwtOptions.Value.Secret != request.Secret)
            throw new AuthException("Invalid client or secret");
        var key = Guid.NewGuid();
        await authKeyRepo.AddEntityAsync(new AuthKey
        {
            CreateDate = DateTime.UtcNow,
            Key = key,
            LastAccessDate = default,
            UserId = request.UserId
        }, cancellationToken);
        
        return key;
    }
}