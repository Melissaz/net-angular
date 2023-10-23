using MediatorApiExample.Mediators.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatorApiExample.Controllers;

[ApiController]
[Route("[controller]")]
public class VelocityController : ControllerBase
{
    private readonly IMediator _mediator;

    public VelocityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<double> Get()
    {
        return await _mediator.Send(new VelocityQuery());
    }
}