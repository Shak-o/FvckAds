using FvckAds.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FvckAds.Persistence.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.Property(x => x.Tag).HasMaxLength(50);
        builder.HasIndex(x => x.Tag).IsUnique();
    }
}