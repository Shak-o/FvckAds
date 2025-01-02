using FvckAds.Domain.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FvckAds.Persistence.EntityConfiguration;

public class AuthKeyConfiguration : IEntityTypeConfiguration<AuthKey>
{
    public void Configure(EntityTypeBuilder<AuthKey> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Key).IsUnique();
    }
}