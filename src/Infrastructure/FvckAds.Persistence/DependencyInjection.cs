using FvckAds.ServiceDefaults;
using Microsoft.Extensions.Hosting;

namespace FvckAds.Persistence;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<UserManagerDbContext>(AspireConstants.PostgresName);
        return builder;
    }
}