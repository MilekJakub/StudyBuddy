using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyBuddy.Infrastructure.Auth;
using StudyBuddy.Infrastructure.EntityFramework;
using StudyBuddy.Infrastructure.Time;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuth(configuration);
        services.AddEntityFramework(configuration);
        
        services.AddScoped<IClock, Clock>();

        return services;
    }
}