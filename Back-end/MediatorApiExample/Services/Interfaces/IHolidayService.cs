using MediatorApiExample.Models;

namespace MediatorApiExample.Services.Interfaces;

public interface IHolidayService
{
    Task<List<CalendarEvent>> GetHolidays(Country country, DateTime startDate);
}