using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyBuddy.Application.Auth;
using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Infrastructure.Auth;
using StudyBuddy.Infrastructure.EntityFramework.Contexts;
using StudyBuddy.Infrastructure.EntityFramework.Repositories;
using StudyBuddy.Infrastructure.EntityFramework.Services;

namespace StudyBuddy.Infrastructure.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(builder =>
        {
            builder.UseSqlServer(configuration.GetConnectionString("StudyBuddyDB"));
        });
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}