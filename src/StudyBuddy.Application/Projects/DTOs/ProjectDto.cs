﻿namespace StudyBuddy.Application.Projects.DTOs;

public record ProjectDto(
    string Topic,
    string Description,
    IEnumerable<ProjectRequirementDto> Requirements,
    IEnumerable<ProjectTechnologyDto> Technologies,
    IEnumerable<ProgrammingLanguageDto> Languages,
    string Difficulty,
    TimeSpan EstimatedTimeToFinish,
    DateTime Deadline,
    string State);