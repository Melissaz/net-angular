using MediatR;
using Microsoft.AspNetCore.Mvc;
using MediatorApiExample.Mediators.Queries;
using MediatorApiExample.Models;

namespace MediatorApiExample.Controllers;

[ApiController]
[Route("[controller]")]
public class HolidaysController : ControllerBase
{
    private readonly IMediator _mediator;

    public HolidaysController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<List<CalendarEvent>>> GetHolidays([FromBody] GetHolidaysQuery request)
    {
        if (request == null)
        {
            return BadRequest("Invalid request payload.");
        }

        var holidays = await _mediator.Send(request);
        return Ok(holidays);
    }
}