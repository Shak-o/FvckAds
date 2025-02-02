namespace FvckAds.ServiceDefaults.Auth;

public class JwtOptions
{
    public required string Secret { get; set; }
    public required string Issuer { get; set; }
}