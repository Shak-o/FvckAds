namespace FvckAds.Application.UserManager.Authentications.Options;

public class JwtOptions
{
    public required string Issuer { get; set; }
    public required string Client { get; set; }
    public required string Secret { get; set; }
}