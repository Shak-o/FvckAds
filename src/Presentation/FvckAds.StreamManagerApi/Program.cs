using FvckAds.Application;
using FvckAds.Persistence;
using FvckAds.StreamManagerApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddServiceDefaults();
builder.AddPersistence();
builder.AddApplication();
builder.Services.AddSignalR();
var clientUrl = builder.Configuration["services:WebClient:http:0"]!;
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        opt =>
        {
            opt.WithOrigins(clientUrl)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});
var app = builder.Build();

app.MapDefaultEndpoints();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.MapHub<ChatHub>("/chat");

app.Run();