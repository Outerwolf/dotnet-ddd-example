using System.Reflection;
using Security.Auth.Application;
using Security.Auth.Application.RegisterUser;

namespace WebApi.Extension.DependencyInjection;

public static class SecurityAuthApplication
{
    public static IServiceCollection AddSecurityAuthApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(SecurityAuthApplicationModule)));
        });
        services.AddScoped<RegisterUser>();
        return services;
    }
}

