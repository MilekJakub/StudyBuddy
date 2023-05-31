using MediatR;

namespace StudyBuddy.Shared.Application.Interfaces;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}