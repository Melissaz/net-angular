using MediatorApiExample.Models;
using MediatorApiExample.Services.Interfaces;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace MediatorApiExample.Services;

public class MockGoogleCalendarHolidayService : IHolidayService
{
    public Task<List<CalendarEvent>> GetHolidays(Country country, DateTime startDate)
    {
        var file = File.ReadAllText($"Services/MockData/GoogleCalendarAPI/{country}.json");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var holidays = JsonSerializer.Deserialize<GoogleCalendarData>(file, options);
            
        DateTime endDate = startDate.AddDays(13);
        // Filter the holidays that fall within this 2-week time range
        var filteredHolidays = holidays.Items
            .Where(item => 
                item.Start.Date >= startDate && 
                item.Start.Date <= endDate)
            .Select(item => new CalendarEvent 
            {
                Id = item.Id,
                Summary = item.Summary,
                Description = item.Description,
                Start = item.Start,
                End = item.End
            })
            .ToList();
        return Task.FromResult(filteredHolidays);
    }
}
