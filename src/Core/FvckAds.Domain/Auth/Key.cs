namespace FvckAds.Domain.Auth;

public class Key : BaseEntity
{
    public required byte[] PrivateKey { get; set; }
    public required byte[] PublicKey { get; set; }
}