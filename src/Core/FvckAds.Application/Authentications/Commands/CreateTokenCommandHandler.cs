using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Domain.Auth;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace FvckAds.Application.Authentications.Commands;

public class CreateTokenCommandHandler(IGenericRepository<Key> keyRepo) : IRequestHandler<CreateTokenCommand, string>
{
    public async Task<string> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
    {
        var date = DateTime.UtcNow.AddHours(-2);
        var keyRecord = await keyRepo.GetAsync(x => x.Id > 0, cancellationToken);
        
        var ecdsa = ECDsa.Create();
        ecdsa.ImportECPrivateKey(Convert.FromBase64String(Convert.ToBase64String(keyRecord.PrivateKey)), out _);

        var securityKey = new ECDsaSecurityKey(ecdsa) { KeyId = Guid.NewGuid().ToString() };
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.EcdsaSha256);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = "YourIssuer",
            Audience = "YourAudience",
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = signingCredentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = tokenHandler.WriteToken(token);
        return jwt;
    }
}