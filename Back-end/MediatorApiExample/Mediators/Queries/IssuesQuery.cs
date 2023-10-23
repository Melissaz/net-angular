using MediatorApiExample.Models;
using MediatR;

namespace MediatorApiExample.Mediators.Queries;

public record IssuesQuery : IRequest<List<Issue>>;