using MediatorApiExample.Mediators.Queries;
using MediatorApiExample.Services.Interfaces;
using MediatR;

namespace MediatorApiExample.Mediators.Handler;

public class VelocityHandler : IRequestHandler<VelocityQuery, double>
{
    private readonly IJiraService _jiraService;

    public VelocityHandler(IJiraService jiraService)
    {
        _jiraService = jiraService;
    }

    public async Task<double> Handle(VelocityQuery request, CancellationToken cancellationToken)
    {
        var sprints = await _jiraService.GetSprintsAsync();
        var lastThreeSprints = sprints.Values.OrderByDescending(s => s.StartDate).Take(3).ToList();

        if (!lastThreeSprints.Any())
        {
            return 0;
        }

        double totalPoints = 0;

        foreach (var sprint in lastThreeSprints)
        {
            var issues = await _jiraService.GetIssuesBySprintAsync(sprint.Name);
            totalPoints += issues.Issues.Sum(issue => issue.Fields.CustomField_10016);
        }

        return totalPoints / 3; // Average over 3 sprints
    }
}