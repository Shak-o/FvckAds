using FvckAds.Domain.Rooms;
using FvckAds.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace FvckAds.Persistence;

public class UserManagerDbContext : DbContext
{
    public UserManagerDbContext(DbContextOptions<UserManagerDbContext> options) : base(options) 
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomUser> RoomUsers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserManagerDbContext).Assembly);
    }
}