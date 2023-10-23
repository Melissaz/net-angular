using MediatorApiExample.Mediators.Queries;
using MediatorApiExample.Models;
using MediatorApiExample.Services.Interfaces;
using MediatR;

namespace MediatorApiExample.Mediators.Handler;

public class GetHolidaysQueryHandler : IRequestHandler<GetHolidaysQuery, List<CalendarEvent>>
{
    private readonly IHolidayService _holidayService;

    public GetHolidaysQueryHandler(IHolidayService holidayService)
    {
        _holidayService = holidayService;
    }

    public async Task<List<CalendarEvent>> Handle(GetHolidaysQuery request, CancellationToken cancellationToken)
    {
        return await _holidayService.GetHolidays(request.Country, request.StartDate);
    }
}