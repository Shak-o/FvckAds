using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using FvckAds.Application.Authentications.Options;
using FvckAds.Application.Exceptions;
using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Domain.Auth;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FvckAds.Application.Authentications.Commands.Handlers;

public class CreateTokenCommandHandler(
    IGenericRepository<Key> keyRepo,
    IAuthKeyRepository authKeyRepo,
    IUnitOfWork unitOfWork,
    IOptions<JwtOptions> options) : IRequestHandler<CreateTokenCommand, string>
{
    public async Task<string> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
    {
        var key = await authKeyRepo.GetAuthKeyByIdAsync(request.ApiKey);
        if (key == null)
        {
            throw new AuthException("Invalid API Key");
        }
        
        key.LastAccessDate = DateTime.UtcNow;
        await unitOfWork.SaveAsync(cancellationToken);
        if (key.User == null)
            throw new AuthException("Key not assigned");
        
        return await GenerateKey(key.User.Tag, cancellationToken);
    }

    private async Task<string> GenerateKey(string userTag, CancellationToken cancellationToken)
    {
        var keyRecord = await keyRepo.GetAsync(x => x.Id > 0, cancellationToken);

        var ecdsa = ECDsa.Create();
        ecdsa.ImportECPrivateKey(Convert.FromBase64String(Convert.ToBase64String(keyRecord.PrivateKey)), out _);

        var securityKey = new ECDsaSecurityKey(ecdsa) { KeyId = Guid.NewGuid().ToString() };
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.EcdsaSha256);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = options.Value.Issuer,
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = signingCredentials,
            Subject = new ClaimsIdentity(new List<Claim>()
            {
                new (ClaimTypes.Name, userTag)
            }),
            Audience = "WebClient"
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = tokenHandler.WriteToken(token);
        return jwt;
    }
}