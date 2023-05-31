using MediatR;

namespace StudyBuddy.Shared.Application.Interfaces;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
{
}