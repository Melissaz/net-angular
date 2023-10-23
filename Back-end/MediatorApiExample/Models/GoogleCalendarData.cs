namespace MediatorApiExample.Models;

public class GoogleCalendarData
{
    public List<CalendarEvent> Items { get; set; }
}

public class CalendarEvent
{
    public string Id { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public CalendarEventDate Start { get; set; }
    public CalendarEventDate End { get; set; }
}

public class CalendarEventDate
{
    public DateTime Date { get; set; }
}
