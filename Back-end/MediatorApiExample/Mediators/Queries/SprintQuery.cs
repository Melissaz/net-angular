using MediatorApiExample.Models;
using MediatR;

namespace MediatorApiExample.Mediators.Queries;

public record SprintQuery : IRequest<List<Sprint>>;