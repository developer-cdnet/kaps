using Kaps.Domain.Kkb.Models;

namespace Kaps.Infrastructure.KkbIntegration.HttpClient.Token;

public interface IKkbTokenClient
{
    ValueTask<KkbTokenModel> GetTokenAsync(bool refreshToken = false, CancellationToken cancellationToken = default);
}