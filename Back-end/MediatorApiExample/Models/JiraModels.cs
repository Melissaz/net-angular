namespace MediatorApiExample.Models;

public record SprintsResponse(bool IsLast, List<Sprint> Values);

public record Sprint(int Id, string Self, string State, string Name, DateTime StartDate, DateTime EndDate);

public record SearchResponse(int Total, List<Issue> Issues);

public record Issue(string Id, Fields Fields);

public record Fields(double CustomField_10016);
