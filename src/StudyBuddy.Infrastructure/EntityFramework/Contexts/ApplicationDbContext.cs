using Microsoft.EntityFrameworkCore;
using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Users;

namespace StudyBuddy.Infrastructure.EntityFramework.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly); 
        base.OnModelCreating(modelBuilder);
    }
}