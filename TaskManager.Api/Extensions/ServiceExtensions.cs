using LiteDB.Async;
using TaskManager.Domain.Repositories;
using TaskManager.Infrastructure.Repositories;

namespace TaskManager.Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCustomServices(this IServiceCollection serviceCollection)
    {
        // Repositories
        var database = new LiteDatabaseAsync("Tasks.db");
        serviceCollection.AddSingleton<ILiteDatabaseAsync, LiteDatabaseAsync>(_ => database);
        serviceCollection.AddSingleton<IMyTaskRepository, MyTaskRepository>();
        serviceCollection.AddSingleton<IAuthenticationRepository, AuthenticationRepository>();
    }
    
    public static void ConfigureApiUtils(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}