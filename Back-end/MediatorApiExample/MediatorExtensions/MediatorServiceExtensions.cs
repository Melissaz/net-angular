using MediatR;
using System.Reflection;

namespace MediatorApiExample.MediatorExtensions;

public static class MediatorServiceExtensions
{
    public static IServiceCollection AddMediatorCQRS(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}