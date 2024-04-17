namespace Kaps.Infrastructure.CorrelationIdProvider;

public class GuidCorrelationIdProvider : ICorrelationIdProvider
{
    public string CorrelationId { get; set; } = Guid.NewGuid().ToString();
}