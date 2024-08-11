var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("Redis");
var postgres = builder.AddPostgres("Postgres").WithDataVolume("PostgresVolume");
var postgresDb = postgres.AddDatabase("UserDb");

builder.AddProject<Projects.FvckAds_StoreApi>("StoreApi");
var streamManager = builder.AddProject<Projects.FvckAds_StreamManagerApi>("StreamManager")
    .WithReference(redis)
    .WithReference(postgresDb);
var webClient = builder.AddProject<Projects.FvckAds_WebClient>("WebClient")
    .WithReference(streamManager);

builder.AddProject<Projects.FvckAds_MigrationService>("MigrationService")
    .WithReference(postgresDb);

builder.Build().Run();