using System.Text.Json;
using MediatorApiExample.Models;
using MediatorApiExample.Services.Interfaces;

namespace MediatorApiExample.Services;

public class GoogleCalendarHolidayService : IHolidayService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public GoogleCalendarHolidayService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<CalendarEvent>> GetHolidays(Country country, DateTime startDate)
    {
        var apiKey = _configuration["GoogleApiKey"];
        var url =
            $"https://www.googleapis.com/calendar/v3/calendars/en.{country}%23holiday%40group.v.calendar.google.com/events?key={apiKey}";

        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var holidays = JsonSerializer.Deserialize<GoogleCalendarData>(content, options);
            
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
            return filteredHolidays;
        }

        return new List<CalendarEvent>();
    }
}