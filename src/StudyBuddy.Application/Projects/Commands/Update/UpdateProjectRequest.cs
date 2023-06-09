﻿using StudyBuddy.Application.Projects.Commands.Create;
using StudyBuddy.Domain.Projects.Enums;
using StudyBuddy.Domain.Projects.Enums.ProjectDifficulty;
using StudyBuddy.Domain.Projects.Enums.ProjectState;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.Update;

public record UpdateProjectRequest(
    Guid ProjectId,
    string? Topic,
    string? Description,
    EstimatedTimeToFinish? EstimatedTimeToFinish,
    DateTime? Deadline,
    ProjectDifficultyId? DifficultyId,
    ProjectStateId? StateId) : ICommand;