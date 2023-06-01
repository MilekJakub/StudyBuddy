using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyBuddy.Infrastructure.EntityFramework.Contexts;

namespace StudyBuddy.Infrastructure.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(builder =>
        {
            builder.UseSqlServer(configuration.GetConnectionString("StudyBuddyDB"));
        });
        
        return services;
    }
}