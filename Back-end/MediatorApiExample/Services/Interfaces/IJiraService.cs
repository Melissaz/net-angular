using MediatorApiExample.Models;

namespace MediatorApiExample.Services.Interfaces;

public interface IJiraService
{
    Task<SprintsResponse> GetSprintsAsync();
    Task<SearchResponse> GetIssuesBySprintAsync(string sprintName);
}