using Microsoft.Extensions.DependencyInjection;

namespace Kaps.Infrastructure.CorrelationIdProvider;

public static class Extensions
{
    public static IServiceCollection AddCorrelationIdGenerator(this IServiceCollection services)
    {
        services.AddSingleton<ICorrelationIdProvider, GuidCorrelationIdProvider>();
        return services;
    }
}