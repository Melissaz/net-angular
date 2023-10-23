using MediatR;

namespace MediatorApiExample.Mediators.Queries;

public record VelocityQuery : IRequest<double>;