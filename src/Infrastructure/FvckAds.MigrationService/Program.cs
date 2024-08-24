using FvckAds.MigrationService;
using FvckAds.Persistence;
using FvckAds.ServiceDefaults;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<ApiDbInitializer<ChatDbContext>>();

builder.AddServiceDefaults();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(ApiDbInitializer<ChatDbContext>.ActivitySourceName));

builder.AddNpgsqlDbContext<ChatDbContext>(AspireConstants.PostgresName);

var app = builder.Build();

app.Run();