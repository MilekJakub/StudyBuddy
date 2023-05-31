using MediatR;
using StudyBuddy.Domain.Users.Events;

namespace StudyBuddy.Application.Users.Commands.RegisterUser;

public class UserRegisteredEventHandler : INotificationHandler<UserRegisteredEvent>
{
    public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}