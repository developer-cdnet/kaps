namespace Kaps.Infrastructure.CorrelationIdProvider;

public interface ICorrelationIdProvider
{
    string CorrelationId { get; }
}