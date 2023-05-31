using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StudyBuddy.Shared.API;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    protected ApiController(ISender sender)
    {
        Sender = sender;
    }
}