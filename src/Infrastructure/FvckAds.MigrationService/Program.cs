using FvckAds.MigrationService;
using FvckAds.Persistence;
using FvckAds.ServiceDefaults;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ApiDbInitializer<UserManagerDbContext>>();

builder.AddServiceDefaults();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(ApiDbInitializer<UserManagerDbContext>.ActivitySourceName));

builder.AddNpgsqlDbContext<UserManagerDbContext>(AspireConstants.PostgresName);

var app = builder.Build();

app.Run();