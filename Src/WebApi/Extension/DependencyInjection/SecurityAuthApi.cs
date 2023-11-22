using Security.Auth.API.Extension;

namespace WebApi.Extension.DependencyInjection;

public static class SecurityAuthApi
{
    public static IServiceCollection AddSecurityAuthApi(this IServiceCollection services)
    {
        services.AddControllers()
            .AddApplicationPart(typeof(SecurityAuthApiExtensions).Assembly);
        return services;
    }
}