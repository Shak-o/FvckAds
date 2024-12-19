var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("Redis")
    .WithLifetime(ContainerLifetime.Persistent);
var postgresPassword = builder.AddParameter("PostgresPassword", true);
var postgres = builder.AddPostgres("Postgres", password: postgresPassword, port: 9943)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume("PostgresVolume2");
var postgresDb = postgres.AddDatabase("UserDb");

builder.AddProject<Projects.FvckAds_StoreApi>("StoreApi", "https");
var streamManager = builder.AddProject<Projects.FvckAds_StreamManagerApi>("StreamManager","http")
    .WithReference(redis)
    .WithReference(postgresDb);
var userManager = builder.AddProject<Projects.FvckAds_UserManagerApi>("UserManager", "http")
    .WithReference(postgresDb);

var webClient = builder.AddProject<Projects.FvckAds_SimpleWeb>("WebClient", "http")
    .WithReference(streamManager)
    .WithReference(userManager);
streamManager.WithReference(webClient);

builder.AddProject<Projects.FvckAds_MigrationService>("MigrationService")
    .WithReference(postgresDb);

builder.Build().Run();