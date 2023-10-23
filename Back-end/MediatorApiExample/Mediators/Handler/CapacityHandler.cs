using MediatorApiExample.Mediators.Queries;
using MediatorApiExample.Services.Interfaces;
using MediatR;

namespace MediatorApiExample.Mediators.Handler;

public class CapacityHandler : IRequestHandler<CapacityQuery, double>
{
    private readonly IJiraService _jiraService;
    private readonly IHolidayService _holidayService;

    private readonly ITeamMemberService _teamMemberService;

    public CapacityHandler(IJiraService jiraService,  IHolidayService holidayService, ITeamMemberService teamMemberService)
    {
        _jiraService = jiraService;
        _holidayService = holidayService;
        _teamMemberService = teamMemberService;
    }

    public async Task<double> Handle(CapacityQuery request, CancellationToken cancellationToken)
    {
        var teamMembers = _teamMemberService.GetTeamMembers();
        var sprints = await _jiraService.GetSprintsAsync();
        var startDate = sprints.Values.MaxBy(sprint => sprint.StartDate).StartDate;
        var totalHolidays = 0;
        
        foreach(var member in teamMembers)
        {
            var memberHolidays = await _holidayService.GetHolidays(member.Location.Country, startDate);
            totalHolidays += memberHolidays.Count;
        }
        
        var daysInSprint = 10; // 2-week sprints

        return (daysInSprint - totalHolidays) * teamMembers.Count;
    }
}