using FvckAds.Application;
using FvckAds.Persistence;
using FvckAds.StreamManagerApi.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

var helper = new JwtHelper();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // Configure the Authority to the expected value for
    // the authentication provider. This ensures the token
    // is appropriately validated.
    options.Authority = "https://localhost:7184"; // TODO: Update URL
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateLifetime = false, // TODO update to true
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = "WebClient",
        IssuerSigningKey = new ECDsaSecurityKey(helper.GetKey(builder.Configuration.GetConnectionString("UserDb")))
    };
    // We have to hook the OnMessageReceived event in order to
    // allow the JWT authentication handler to read the access
    // token from the query string when a WebSocket or 
    // Server-Sent Events request comes in.

    // Sending the access token in the query string is required when using WebSockets or ServerSentEvents
    // due to a limitation in Browser APIs. We restrict it to only calls to the
    // SignalR hub in this code.
    // See https://docs.microsoft.com/aspnet/core/signalr/security#access-token-logging
    // for more information about security considerations when using
    // the query string to transmit the access token.
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            // If the request is for our hub...
            // var path = context.HttpContext.Request.Path;
            // if (!string.IsNullOrEmpty(accessToken) &&
            //     (path.StartsWithSegments("/hubs/chat")))
            // {
            //     // Read the token out of the query string
            //     context.Token = accessToken;
            // }
            context.Token = accessToken;
            return Task.CompletedTask;
        }
    };
});

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

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.MapHub<ChatHub>("/chat");

app.Run();