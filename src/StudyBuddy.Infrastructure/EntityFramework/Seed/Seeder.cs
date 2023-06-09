using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Infrastructure.EntityFramework.Contexts;

namespace StudyBuddy.Infrastructure.EntityFramework.Seed;

public static class Seeder
{
    public static async Task Seed(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        
        var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

        if (dbContext is null)
        {
            throw new ExternalException("Error occured while trying to seed data. Cannot get required services.");
        }

        await dbContext.Database.MigrateAsync();
        await dbContext.Database.EnsureCreatedAsync();
        
        if (!(await dbContext.Users.AnyAsync()))
        {
            User admin = new User(
                id: new UserId(Guid.Parse("D72A8C94-A7ED-4E57-B3C3-6532CEC4191C")),
                username:);

            await userManager.CreateAsync(admin, "SuperSecret@1"); 
            await userManager.AddToRoleAsync(admin, "Administrator");
            
            
            ApplicationUser standard = new()
            {
                 Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                 Email = "user@localhost",
                 NormalizedEmail = "USER@LOCALHOST",
                 UserName = "milekjakub",
                 NormalizedUserName = "USER@LOCALHOST.COM",
                 EmailConfirmed = true
            };                
            
            await userManager.CreateAsync(standard, "SuperSecret@1"); 
            await userManager.AddToRoleAsync(standard, "User");
        }
            
        await identityDbContext.SaveChangesAsync();
    }
}