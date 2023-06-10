# Study Buddy

## Student project management application.

Studdy Buddy is an application that allows the management of student projects.

**Projects**: The application revolves around creating, editing, and managing projects. Projects have various attributes such as topic, description, requirements, technology stack, programming languages, level of difficulty, and dates associated with them.

**Teams**: Each project is associated with a team that consists of members. Teams have names, membership information, and a list of completed projects.

**Roles and Leadership**: Users within the system can have different roles within a project, such as developer, tester, leader, or devops. The user who creates a project initially becomes its leader but can transfer this role to another member of the project team.

**Project Workflow**: Projects progress through different states, including created, forming team, in progress, testing, and completed. These states represent the various stages of a project's lifecycle.

**User Management**: The application includes user management features like registration verification and profile editing.

## Entities

**User:**
- Id
- Username
- Email
- PasswordHash
- Role
- Firstname
- Lastname
- RegisterNumber
- CreatedAt
- Memberships

**Project:**
- Id
- Topic
- Description
- EstimatedTime
- Deadline
- Team
- Requirements
- Technologies
- Programming Languages
- ProjectDifficulty
- ProjectState

**Team:**
- Id
- Name
- Description
- Memberships
- Projects

## Project structure

This project was created with Clean Architecture and Domain-Driven Design in mind.

It is not created with Test-Driven Development but has unit tests for domain entities.

The main goal was to learn Clean Architecture and Domain-Driven Design by building whole application using those two architectural patterns.

The project is not finished, but have implemented core functionalities.

Authorization is done by using JWT Tokens generation, but there is no authentication.

Since there is no authentication some of core concepts are not implemented yet.

## Buzzwords

- Clean Architecture
- Domain-Driven Design
- CQRS
- ASP.NET CORE
- Entity Framework
- SQL Server
- Clean Code