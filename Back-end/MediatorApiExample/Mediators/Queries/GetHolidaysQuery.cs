using MediatorApiExample.Models;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MediatorApiExample.Mediators.Queries;

public class GetHolidaysQuery : IRequest<List<CalendarEvent>>
{
    public Country Country { get; set; }
    public DateTime StartDate { get; set; }
}