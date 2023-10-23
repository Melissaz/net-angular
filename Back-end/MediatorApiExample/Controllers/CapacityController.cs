using MediatorApiExample.Mediators.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorApiExample.Controllers;

[ApiController]
[Route("[controller]")]
public class CapacityController : ControllerBase
{
    private readonly IMediator _mediator;

    public CapacityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<double> Get()
    {
        return await _mediator.Send(new CapacityQuery());
    }
}