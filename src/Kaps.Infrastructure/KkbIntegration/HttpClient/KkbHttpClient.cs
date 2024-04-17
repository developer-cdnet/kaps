using System.Net.Http.Json;
using Kaps.Domain.Kkb.Requests;
using Kaps.Domain.Kkb.Responses;
using Kaps.Domain.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Kaps.Infrastructure.KkbIntegration.HttpClient;

public class KkbHttpClient : IKkbClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOptions<KkbOptions> _kkbOptions;

    public KkbHttpClient(IHttpClientFactory httpClientFactory, IOptions<KkbOptions> kkbOptions)
    {
        _httpClientFactory = httpClientFactory;
        _kkbOptions = kkbOptions;
    }


    public async Task<KkbQueryResponse?> QueryAsync(KapsQueryRequest request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient("kkb-client");
        var response =
            await client.PostAsJsonAsync(_kkbOptions.Value.HttpClient.Endpoint.Query, request, cancellationToken);
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<KkbQueryResponse>(responseContent);
    }
    
    public async Task<KkbCreateNotificationResponse?> CreateNotificationAsync(KapsCreateNotificationRequest request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient("kkb-client");
        var response =
            await client.PostAsJsonAsync(_kkbOptions.Value.HttpClient.Endpoint.CreateUpdate, request, cancellationToken);
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<KkbCreateNotificationResponse>(responseContent);
    }
    
    public async Task<KkbUpdateNotificationResponse?> UpdateNotificationAsync(KapsUpdateNotificationRequest request, CancellationToken cancellationToken = default)
    {
        var client = _httpClientFactory.CreateClient("kkb-client");
        var response =
            await client.PostAsJsonAsync(_kkbOptions.Value.HttpClient.Endpoint.CreateUpdate, request, cancellationToken);
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<KkbUpdateNotificationResponse>(responseContent);
    }
}