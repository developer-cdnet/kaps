using System.Net;
using System.Net.Http.Headers;
using Kaps.Domain.Exceptions;
using Kaps.Domain.Kkb.Responses;
using Kaps.Infrastructure.KkbIntegration.HttpClient.Token;
using Newtonsoft.Json;

namespace Kaps.Infrastructure.KkbIntegration.HttpClient.DelegationHandler;

public class KkbClientDelegationHandler : DelegatingHandler
{
    private readonly IKkbTokenClient _tokenClient;

    public KkbClientDelegationHandler(IKkbTokenClient tokenClient)
    {
        _tokenClient = tokenClient ?? throw new ArgumentNullException(nameof(tokenClient));
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        await SetAuthorizationHeaderAsync(request, false, cancellationToken);
        var response = await base.SendAsync(request, cancellationToken);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            response.Dispose();
            await SetAuthorizationHeaderAsync(request, true, cancellationToken);
            response = await base.SendAsync(request, cancellationToken);
        }

        if (!response.IsSuccessStatusCode)
        {
            if (!response.StatusCode.Equals(HttpStatusCode.BadRequest))
            { 
                var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
                throw new ApplicationException(
                    $"Error on calling kkb with statusCode: {response.StatusCode}, content: {errorContent}");
            }
        }

        return response;
    }

    private async ValueTask SetAuthorizationHeaderAsync(HttpRequestMessage request, bool refreshToken = false,
        CancellationToken cancellationToken = default)
    {
        var token = await _tokenClient.GetTokenAsync(refreshToken, cancellationToken);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
    }
}