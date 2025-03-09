using Microsoft.Extensions.Hosting;

namespace FvckAds.StoreApi.Persistence;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder build)
    {
        build.AddNpgsqlDbContext<StoreDbContext>("StoreDb");
        return build;
    }
}