using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FvckAds.StoreApi.Application;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        
        return builder;
    }
}