namespace MediatorApiExample.Models;

public record SprintsResponse(bool IsLast, List<Sprint> Values);

public record Sprint(int Id, string Self, string State, string Name, DateTime StartDate, DateTime EndDate);

public record SearchResponse(int Total, List<Issue> Issues);

public record Issue(string Id, string Key, Fields Fields);

public record Fields(IssueType IssueType, string Created, double CustomField_10016, List<Sprint> CustomField_10020, IssueStatus Status);

public record IssueType(string Id, string Description, string IconUrl, string Name);

public record IssueStatus(string Name, string IconUrl);
