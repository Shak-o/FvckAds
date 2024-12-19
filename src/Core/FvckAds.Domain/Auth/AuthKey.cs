using FvckAds.Domain.Users;

namespace FvckAds.Domain.Auth;

public class AuthKey : BaseEntity
{
    public Guid Key { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public DateTime LastAccessDate { get; set; }
    public bool AlreadyUsed { get; set; }
}