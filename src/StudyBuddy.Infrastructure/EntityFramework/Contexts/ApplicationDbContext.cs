using Microsoft.EntityFrameworkCore;
using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Projects.Enums.ProjectDifficulty;
using StudyBuddy.Domain.Projects.Enums.ProjectState;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Teams.Entities;
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
    
    public DbSet<ProjectRequirement> ProjectRequirements { get; set; }
    public DbSet<Technology> ProjectTechnologies { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<ProjectDifficulty> ProjectDifficulties { get; set; }
    public DbSet<ProjectState> ProjectStates { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly); 
        base.OnModelCreating(modelBuilder);
    }
}