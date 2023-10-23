using MediatR;

namespace MediatorApiExample.Mediators.Queries;

public record CapacityQuery : IRequest<double>;