using System.Text;
using MediatorApiExample.Models;
using MediatorApiExample.Services.Interfaces;

namespace MediatorApiExample.Services;

public class JiraService : IJiraService
{
    private readonly HttpClient _httpClient;
    
    public JiraService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        // Set up authentication
        var authorizationKey = configuration["AuthorizationKey"];
        var byteArray = Encoding.ASCII.GetBytes(authorizationKey);
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
    }
    
    public async Task<SprintsResponse> GetSprintsAsync()
    {
        return await _httpClient.GetFromJsonAsync<SprintsResponse>(
            "https://hf-sandbox.atlassian.net/rest/agile/latest/board/1/sprint");
    }
    public async Task<SearchResponse> GetIssuesBySprintAsync(string sprintName)
    {
        var searchBody = new { jql = $"SprintController='{sprintName}'", maxResults = 1000, startAt = 0 };
        var searchResponse =
            await _httpClient.PostAsJsonAsync("https://hf-sandbox.atlassian.net/rest/api/2/search", searchBody);
        return await searchResponse.Content.ReadFromJsonAsync<SearchResponse>();
    }
}