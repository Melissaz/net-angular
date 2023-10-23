using MediatorApiExample.Mediators.Queries;
using MediatorApiExample.Models;
using MediatorApiExample.Services.Interfaces;
using MediatR;

namespace MediatorApiExample.Mediators.Handler;

public class SprintHandler : IRequestHandler<SprintQuery, List<Sprint>>
{
    private readonly IJiraService _jiraService;

    public SprintHandler(IJiraService jiraService)
    {
        _jiraService = jiraService;
    }

    public async Task<List<Sprint>> Handle(SprintQuery request, CancellationToken cancellationToken)
    {
        var sprints = await _jiraService.GetSprintsAsync();
        var latestSprint = sprints.Values.OrderByDescending(s => s.StartDate).Take(1).ToList();
        return latestSprint;
    }
}