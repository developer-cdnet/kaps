using System.Net.Http.Headers;
using Kaps.Domain.Kkb.Models;
using Kaps.Domain.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Kaps.Infrastructure.KkbIntegration.HttpClient.Token;

public class KkbTokenClient : IKkbTokenClient
{
    private const string CacheKey = "KkbToken";
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly KkbOptions _kkbOptions;
    private readonly IMemoryCache _memoryCache;
    private readonly SemaphoreSlim _tokenRefreshLock = new SemaphoreSlim(1, 1);

    public KkbTokenClient(IMemoryCache memoryCache, IHttpClientFactory httpClientFactory,
        IOptionsMonitor<KkbOptions> kkbOptionsMonitor)
    {
        _httpClientFactory = httpClientFactory;
        _kkbOptions = kkbOptionsMonitor.CurrentValue;
        _memoryCache = memoryCache;
    }


    public async ValueTask<KkbTokenModel> GetTokenAsync(bool refreshToken = false,
        CancellationToken cancellationToken = default)
    {
        if (!refreshToken && _memoryCache.TryGetValue(CacheKey, out KkbTokenModel cachedToken))
        {
            return cachedToken;
        }

        await _tokenRefreshLock.WaitAsync(cancellationToken);
        try
        {
            if (!refreshToken)
            {
                if (_memoryCache.TryGetValue(CacheKey, out cachedToken))
                {
                    return cachedToken;
                }
            }
            else
            {
                _memoryCache.Remove(CacheKey);
            }

            var newToken = await FetchNewTokenAsync(cancellationToken);
            _memoryCache.Set(CacheKey, newToken, TimeSpan.FromSeconds(newToken.ExpiresIn - 5));
            return newToken;
        }
        finally
        {
            _tokenRefreshLock.Release();
        }
    }


    private async Task<KkbTokenModel> FetchNewTokenAsync(CancellationToken cancellationToken = default)
    {
        //toDOCihan: sil bu kısmı

        return new KkbTokenModel()
        {
            AccessToken =
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
            ConsentedOn = 1644854400, // Assuming this is a Unix timestamp for 02/15/2022
            ExpiresIn = 3600,
            Scope = "deneme",
            TokenType = "deneme"
        };
        
        
        var client = _httpClientFactory.CreateClient("kkb-token");
        var options = _kkbOptions.HttpClient.OAuth;

        var request = new HttpRequestMessage(HttpMethod.Post,_kkbOptions.HttpClient.Endpoint.Token);
        var keyValues = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("grant_type", options.GrantType),
            new KeyValuePair<string, string>("client_id", options.ClientId),
            new KeyValuePair<string, string>("client_secret", options.ClientSecret),
            new KeyValuePair<string, string>("scope", options.Scope) 
        };

        request.Content = new FormUrlEncodedContent(keyValues);
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

        var response = await client.SendAsync(request, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonConvert.DeserializeObject<KkbTokenModel>(responseContent);
        }
        
        var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);
        throw new ApplicationException($"Error on getting token: {response.StatusCode}, content: {errorContent}");
    }
}