using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Projects.Enums.ProjectDifficulty;
using StudyBuddy.Domain.Projects.ValueObjects;
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
        
        if (!await dbContext.Users.AnyAsync())
        {
            var user =
                new User(
                id: new UserId(Guid.Parse("D1F51D19-AD78-40C6-83D7-3C7F38F37C79")),
                username: new Username("kamilz"),
                email: new Email("kamil.zydlo@microsoft.wsei.edu.pl"),
                hash: new PasswordHash("AQAAAAIAAYagAAAAEDslygmcPD8WrSrQSWbwqH5F2CeXH70I1i4/VbkN2CUCFh88iclYygFdvo+gCNH1Hw=="),
                role: new UserRole("user"),
                firstname: new Firstname("Kamil"),
                lastname: new Lastname("Żydło"),
                registerNumber: new RegisterNumber("12312"),
                createdAt: DateTime.UtcNow);
            
            var admin =
                new User(
                id: new UserId(Guid.Parse("C3E36281-5D7E-47F9-9F79-EF0BA2E8822B")),
                username: new Username("admin"),
                email: new Email("admin@studybuddy.com"),
                hash: new PasswordHash("AQAAAAIAAYagAAAAEESMSSusaRBwWVr9u1H4/kAKlPvCbgH3hczuFaGWR7xUVxNQwzhi1PFJtoQUGdC+hA=="),
                role: new UserRole("admin"),
                firstname: new Firstname("Admin"),
                lastname: new Lastname("Admin"),
                registerNumber: new RegisterNumber("Admin"),
                createdAt: DateTime.UtcNow);

            dbContext.Users.Add(user);
            dbContext.Users.Add(admin);
            
            await dbContext.SaveChangesAsync();
        }

        if (!await dbContext.Projects.AnyAsync())
        {
            var project =
                new Project(
                    id: new ProjectId(Guid.Parse("962E210E-7477-4377-95E4-216781F5A70F")),
                    topic: new ProjectTopic("Study Buddy"),
                    description: new ProjectDescription("Managing studnets' projects, and more!"),
                    difficulty: await dbContext.ProjectDifficulties.SingleAsync(d => (byte)d.Id == 4),
                    estimatedTimeToFinish: new EstimatedTime(5, 0, 0, 0),
                    deadline: new Deadline(new DateTime(2023, 06, 13, 17, 0, 0, 0)),
                    state: await dbContext.ProjectStates.SingleAsync(s => (byte)s.Id == 5),
                    creator: await dbContext.Users.SingleAsync(u => u.Id == new UserId(Guid.Parse("D1F51D19-AD78-40C6-83D7-3C7F38F37C79"))));

            var requirements = new List<ProjectRequirement>()
            {
                new ProjectRequirement(
                    "Application should have entities: Project, Team, User", "some description..."),
                new ProjectRequirement("Every project should have: requirements, technologies, programming languages.",
                    "some description..."),
                new ProjectRequirement("Every team should have members and projects.", "some description..."),
                new ProjectRequirement("Closed teams should have a leader that can add and kick members", "some description..."),
                new ProjectRequirement("Open projects should accept every user that wants to join it.", "some description..."),
                new ProjectRequirement("Every team member should have role representing field of work.", "some description...")
            };

            var technologies = new List<Technology>()
            {
                new Technology("ASP.NET", "some description...", null),
                new Technology("EntityFramework", "some description...", null),
                new Technology("JWT Token Generation", "some description...", null),
                new Technology("MS SQL Server", "some description...", null),
                new Technology("XUnit", "some description...", null)
            };

            var languages = new List<ProgrammingLanguage>()
            {
                new ProgrammingLanguage("C#", "10"),
                new ProgrammingLanguage("SQL", null),
                new ProgrammingLanguage("JSON", null)
            };
            
            project.AddRequirements(requirements);
            project.AddTechnologies(technologies);
            project.AddProgrammingLanguages(languages);

            dbContext.Projects.Add(project);
            
            await dbContext.SaveChangesAsync();
        }
    }
}