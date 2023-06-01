using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace StudyBuddy.Infrastructure.EntityFramework.Contexts;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(@"C:\Users\Jakub.Milek\Desktop\StudyBuddy\src\StudyBuddy.Api")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = configuration.GetConnectionString("StudyBuddyDB");
        
        builder.UseSqlServer(connectionString);

        return new ApplicationDbContext(builder.Options);
    } 
}