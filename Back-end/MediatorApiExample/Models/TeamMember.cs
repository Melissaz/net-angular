namespace MediatorApiExample.Models;

public class TeamMember
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Location Location { get; set; }
}

public class Location
{
    public string Id { get; set; }
    public Country Country { get; set; }
    public string Region { get; set; }
}