using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FvckAds.Application;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection)));
        return builder;
    }
}