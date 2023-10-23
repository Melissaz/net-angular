using MediatorApiExample.Mediators.Queries;
using MediatorApiExample.Models;
using MediatorApiExample.Services.Interfaces;
using MediatR;

namespace MediatorApiExample.Mediators.Handler;

public class IssuesHandler : IRequestHandler<IssuesQuery, List<Issue>>
{
    private readonly IJiraService _jiraService;

    public IssuesHandler(IJiraService jiraService)
    {
        _jiraService = jiraService;
    }

    public async Task<List<Issue>> Handle(IssuesQuery request, CancellationToken cancellationToken)
    {
        var sprints = await _jiraService.GetSprintsAsync();
        var latestSprints = sprints.Values.MaxBy(s => s.StartDate);
        var response = await _jiraService.GetIssuesBySprintAsync(latestSprints.Name);
        return response.Issues;
    }
}