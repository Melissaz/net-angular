using MediatorApiExample.Models;
using MediatorApiExample.Services.Interfaces;
using Newtonsoft.Json;

namespace MediatorApiExample.Services;

public class MockJiraService : IJiraService
{
    public Task<SprintsResponse> GetSprintsAsync()
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(basePath, "Services", "MockData", "JiraAPI", "sprints.json");
        var file = File.ReadAllText(filePath);
        var response = JsonConvert.DeserializeObject<SprintsResponse>(file);

        return Task.FromResult(response);
    }

    public Task<SearchResponse> GetIssuesBySprintAsync(string sprintName)
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var filePath = Path.Combine(basePath, "Services", "MockData", "JiraAPI", "backlog.json");
        var file = File.ReadAllText(filePath);
        var response = JsonConvert.DeserializeObject<SearchResponse>(file);

        if (response?.Issues != null)
        {
            var selectedIssues = response.Issues
                .Where(issue => issue.Fields.CustomField_10020 != null &&
                                issue.Fields.CustomField_10020.Any(sprint =>
                                    sprint.Name.Equals(sprintName, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            var selectedResponse = new SearchResponse(selectedIssues.Count, selectedIssues);
            return Task.FromResult(selectedResponse);
        }
        return Task.FromResult(new SearchResponse(0, new List<Issue>()));
    }
}
