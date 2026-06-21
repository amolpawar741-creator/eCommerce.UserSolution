using eCommerce.Core.RepositoriesContract;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register infrastructure services here
        // For example:
        // services.AddScoped<IMyService, MyService>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();

        return services;
    }
}

