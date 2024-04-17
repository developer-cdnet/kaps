using Kaps.Domain.Kkb.Requests;
using Kaps.Domain.Kkb.Responses;

namespace Kaps.Infrastructure.KkbIntegration;

public interface IKkbClient
{
    Task<KkbQueryResponse?> QueryAsync(KapsQueryRequest request, CancellationToken cancellationToken = default);
    Task<KkbCreateNotificationResponse?> CreateNotificationAsync(KapsCreateNotificationRequest request, CancellationToken cancellationToken = default);
    Task<KkbUpdateNotificationResponse?> UpdateNotificationAsync(KapsUpdateNotificationRequest request, CancellationToken cancellationToken = default);

}