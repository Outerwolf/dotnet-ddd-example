using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security.Auth.Domain.Interface;
using Security.Auth.Infrastructure.Persitance;
using Security.Auth.Infrastructure.Persitence.Repositories;

namespace Security.Auth.Infrastructure.DependencyInjection;

public static class PersistenceDependency
{
    public static IServiceCollection AddSecurityAuthInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<UserSecurityDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("SQLServer")));
        services.AddScoped<UserSecurityRepository, SqlServerUserSecurityRepository>();
        return services;
    }
}