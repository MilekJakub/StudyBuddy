using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Projects.Enums;
using StudyBuddy.Domain.Projects.Enums.ProjectDifficulty;
using StudyBuddy.Domain.Projects.Enums.ProjectState;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Users.ValueObjects;

namespace StudyBuddy.Infrastructure.EntityFramework.Configurations;

public class ProjectConfiguration
	: IEntityTypeConfiguration<Project>,
	  IEntityTypeConfiguration<ProjectRequirement>,
	  IEntityTypeConfiguration<ProjectTechnology>,
	  IEntityTypeConfiguration<ProgrammingLanguage>,
	  IEntityTypeConfiguration<ProjectDifficulty>,
	  IEntityTypeConfiguration<ProjectState>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder
	        .Property(u => u.Id)
	        .HasConversion(
		        id => id.Value,
		        id => new ProjectId(id));
        
        builder
			.Property(p => p.Topic)
			.HasConversion(
				topic => topic.ToString(),
				topic => new ProjectTopic(topic))
			.HasColumnName("Topic")
			.IsRequired();

		builder
			.Property(p => p.Description)
			.HasConversion(
				description => description.ToString(),
				description => new ProjectDescription(description))
			.HasColumnName("Description")
			.IsRequired();

		builder
			.Property(p => p.ProjectDifficultyId)
			.HasConversion<byte>();
		
		builder
			.Property(p => p.ProjectDifficulty)
			.HasConversion(
				difficulty => difficulty.ToString(),
				difficulty => new ProjectDifficulty(difficulty))
			.HasColumnName("ProjectDifficulty")
			.IsRequired();

		builder
			.Property(p => p.EstimatedTimeToFinish)
			.HasColumnName("EstimatedTimeToFinish")
			.IsRequired();
		
		builder
			.Property(p => p.Deadline)
			.HasColumnName("Deadline")
			.IsRequired();
		
		builder
			.Property(p => p.ProjectStateId)
			.HasConversion<byte>();
		
		builder
			.Property(p => p.ProjectState)
			.HasConversion(
				state => state.ToString(),
				state => new ProjectState(state))
			.HasColumnName("ProjectState")
			.IsRequired();

		builder
			.HasOne(p => p.Team)
			.WithMany(t => t.Projects);

		// builder
		// 	.HasOne(p => p.ProjectDifficulty)
		// 	.WithMany(pd => pd.Projects)
		// 	.HasForeignKey(p => p.ProjectDifficultyId);

		// builder
		// 	.HasOne(p => p.ProjectState)
		// 	.WithMany(pd => pd.Projects)
		// 	.HasForeignKey(p => p.ProjectStateId);

		builder.HasMany(p => p.Requirements);
		builder.HasMany(p => p.Technologies);
		builder.HasMany(p => p.ProgrammingLanguages);
		
        builder.ToTable("Projects");
    }
    
    public void Configure(EntityTypeBuilder<ProjectRequirement> builder)
    {
	    builder.Property<Guid>("Id");
	    builder.Property(pr => pr.Name);
	    builder.Property(pr => pr.Description);
	    builder.ToTable("ProjectRequirements");
    }

    public void Configure(EntityTypeBuilder<ProjectTechnology> builder)
    {
	    builder.Property<Guid>("Id");
	    builder.Property(pt => pt.Name);
	    builder.Property(pt => pt.Description);
	    builder.Property(pt => pt.Version);
	    builder.ToTable("ProjectTechnologies");
    }

    public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
    {
	    builder.Property<Guid>("Id");
	    builder.Property(pl => pl.Name);
	    builder.Property(pl => pl.Version);
	    builder.ToTable("ProjectProgrammingLanguages");
    }

    public void Configure(EntityTypeBuilder<ProjectDifficulty> builder)
    {
	    builder.HasKey(pd => pd.Id);

	    builder
			.Property(pd => pd.Id)
			.HasConversion<byte>();
		
		builder
			.HasData
			(
				Enum.GetValues(typeof(ProjectDifficultyId))
				.Cast<ProjectDifficultyId>()
				.Select(@enum => new ProjectDifficulty(@enum.ToString())
				{
					Id = @enum,
				})
			);
		
	    builder.ToTable("ProjectDifficulties");
    }

    public void Configure(EntityTypeBuilder<ProjectState> builder)
    {
	    builder.HasKey(ps => ps.Id);
	    
	    builder
			.Property(ps => ps.Id)
			.HasConversion<byte>();
		
		builder
			.HasData
			(
				Enum.GetValues(typeof(ProjectStateId))
				.Cast<ProjectStateId>()
				.Select(@enum => new ProjectState(@enum.ToString())
				{
					Id = @enum,
				})
			);
		
	    builder.ToTable("ProjectStates");
    }
}