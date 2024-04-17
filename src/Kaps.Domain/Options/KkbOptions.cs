namespace Kaps.Domain.Options;

public class KkbOptions
{
    public const string SectionName = "Kkb";

    public HttpClientOptions HttpClient { get; set; } = new HttpClientOptions();
}

public class HttpClientOptions
{
    public OAuthOptions OAuth { get; set; } = new OAuthOptions();

    public ResilienceOptions Resilience { get; set; } = new ResilienceOptions();
    public EndpointOptions Endpoint { get; set; } = new EndpointOptions();

    public int Timeout { get; set; } = 30; // seconds
}

public class OAuthOptions
{
    public string ClientId { get; set; }

    public string ClientSecret { get; set; }

    public string Scope { get; set; } = "gks_read gks_write";

    public string GrantType { get; set; } = "client_credentials";
}

public class ResilienceOptions
{
    public int RetryCount { get; set; } = 5;

    public int RetryDelay { get; set; } = 200;

    public int CircuitBreakerCount { get; set; } = 5;

    public int CircuitBreakerDelay { get; set; } = 200;
}

public class EndpointOptions
{
    public string BaseUri { get; set; } = "https://apigwb.kkb.com.tr/inb/kaps";

    public string Token { get; set; } = "/oauth-provider/oauth2/token";

    public string Query { get; set; } = "/sorgu";
    
    public string CreateUpdate { get; set; } = "/bildirim"; 
}
