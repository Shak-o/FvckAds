using FvckAds.Domain.Rooms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FvckAds.Persistence.EntityConfiguration;

public class RoomUserConfiguration : IEntityTypeConfiguration<RoomUser>
{
    public void Configure(EntityTypeBuilder<RoomUser> builder)
    {
        builder.ToTable("RoomUsers");

        builder.Property(x => x.ConnectionId).HasMaxLength(255);

        builder.HasIndex(x => new { x.UserId, x.RoomId, x.ConnectionId });

        builder.HasOne(x => x.User).WithMany(x => x.RoomUsers).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Room).WithMany(x => x.RoomUsers).HasForeignKey(x => x.RoomId);
    }
}