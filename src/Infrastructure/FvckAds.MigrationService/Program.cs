// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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