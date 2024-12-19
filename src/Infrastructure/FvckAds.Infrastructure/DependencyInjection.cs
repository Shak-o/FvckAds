using FvckAds.Client.Application.WebClient.ApiClients;
using FvckAds.Infrastructure.ApiClients;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FvckAds.Infrastructure;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.Services.AddHttpClient("UserManagerApi", opt =>
        {
            opt.BaseAddress = new Uri("http://UserManager");
        });

        builder.Services.AddScoped<IUserManagerApi, UserManagerApiClient>();
        return builder;
    }
}