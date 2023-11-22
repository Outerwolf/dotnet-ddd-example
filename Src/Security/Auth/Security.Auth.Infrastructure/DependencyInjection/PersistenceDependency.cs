using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Security.Auth.Domain;
using Security.Auth.Domain.Interface;
using Security.Auth.Infrastructure.Persitance;

namespace Security.Auth.Infrastructure.DependencyInjection;

public static class PersistenceDependency
{
    public static IServiceCollection AddSecurityAuthInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<SecurityAuthRepository, InMemorySecurityAuthRepository>();
        return services;
    }
}