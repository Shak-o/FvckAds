using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Domain.Rooms;
using FvckAds.Domain.Users;
using FvckAds.Persistence.Repositories;
using FvckAds.ServiceDefaults;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FvckAds.Persistence;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddPersistence(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<UserManagerDbContext>(AspireConstants.PostgresName);
        
        builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
        builder.Services.AddScoped<IGenericRepository<Room>, GenericRepository<Room>>();
        builder.Services.AddScoped<IGenericRepository<RoomUser>, GenericRepository<RoomUser>>();
        builder.Services.AddScoped<IUsersRepository, UserRepository>();
        
        return builder;
    }
}