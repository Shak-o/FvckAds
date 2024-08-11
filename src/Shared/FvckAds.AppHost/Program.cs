var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("Redis");
var postgresPassword = builder.AddParameter("PostgresPassword", true);
var postgres = builder.AddPostgres("Postgres", password: postgresPassword).WithDataVolume("PostgresVolume2");
var postgresDb = postgres.AddDatabase("UserDb");

builder.AddProject<Projects.FvckAds_StoreApi>("StoreApi");
var streamManager = builder.AddProject<Projects.FvckAds_StreamManagerApi>("StreamManager")
    .WithReference(redis)
    .WithReference(postgresDb);

var userManager = builder.AddProject<Projects.FvckAds_UserManagerApi>("UserManager")
    .WithReference(postgresDb);

var webClient = builder.AddProject<Projects.FvckAds_WebClient>("WebClient")
    .WithReference(streamManager);

builder.AddProject<Projects.FvckAds_MigrationService>("MigrationService")
    .WithReference(postgresDb);

builder.Build().Run();