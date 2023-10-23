using MediatorApiExample.Mediators.Queries;
using MediatorApiExample.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorApiExample.Controllers;

[ApiController]
[Route("[controller]")]
public class IssuesController : ControllerBase
{
    private readonly IMediator _mediator;

    public IssuesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<Issue>> Get()
    {
        return await _mediator.Send(new IssuesQuery());
    }
}