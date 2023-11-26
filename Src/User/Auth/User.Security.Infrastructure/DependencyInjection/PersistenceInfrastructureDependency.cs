using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security.Auth.Domain.Interface;
using Security.Auth.Infrastructure.Persitance;
using Security.Auth.Infrastructure.Persitence.Repositories;
using Security.Auth.Infrastructure.Security;

namespace Security.Auth.Infrastructure.DependencyInjection;

public static class PersistenceInfrastructureDependency
{
    public static IServiceCollection AddSecurityAuthInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<UserSecurityDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("SQLServer")));
        services.AddScoped<UserSecurityRepository, SqlServerUserSecurityRepository>();
        services.AddSingleton<IPasswordHasher, PasswordHasherWithSaltAndPepper>();
        return services;
    }
}