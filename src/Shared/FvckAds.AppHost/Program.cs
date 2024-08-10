var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FvckAds_StoreApi>("StoreApi");
builder.AddProject<Projects.FvckAds_StreamManagerApi>("StreamManager");
builder.AddProject<Projects.FvckAds_WebClient>("WebClient");

builder.Build().Run();