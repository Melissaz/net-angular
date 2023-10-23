using MediatorApiExample.Mediators.Queries;
using MediatorApiExample.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorApiExample.Controllers;

[ApiController]
[Route("[controller]")]
public class SprintController : ControllerBase
{
    private readonly IMediator _mediator;

    public SprintController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("current")]
    public async Task<List<Sprint>> Get()
    {
        return await _mediator.Send(new SprintQuery());
    }
}