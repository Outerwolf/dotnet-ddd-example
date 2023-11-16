using MediatR;
using Security.Auth.Application.RegisterUser;

namespace WebApi.Extension.DependencyInjection;

public static class SecurityAuthApplication
{
    public static IServiceCollection AddSecurityAuthApplication(this IServiceCollection services)
    {
        services.AddScoped<RegisterUser>();
        return services;
    }
}

