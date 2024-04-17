using Kaps.Domain.Options;
using Kaps.Infrastructure.CorrelationIdProvider;
using Kaps.Infrastructure.KapsContext;
using Kaps.Infrastructure.KkbIntegration;
using Kaps.Infrastructure.KkbIntegration.HttpClient;
using Kaps.Infrastructure.KkbIntegration.HttpClient.DelegationHandler;
using Kaps.Infrastructure.KkbIntegration.HttpClient.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;

namespace Kaps.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IKkbTokenClient, KkbTokenClient>();
        services.AddTransient<IKkbClient, KkbHttpClient>();
        services.AddKkbHttpClient(); 
        services.AddCorrelationIdGenerator(); 
        services.AddTransient<IKapsContext, DefaultKapsContext>();
        services.AddKapsDbContext(configuration);
        return services;
    }

    
    private static IServiceCollection AddKkbHttpClient(this IServiceCollection services)
    {
        services.AddHttpClient();

        services.AddHttpClient("kkb-token")
            .ConfigureHttpClient((serviceProvider, httpClient) =>
            {
                var kkbOptions = serviceProvider.GetRequiredService<IOptions<KkbOptions>>().Value;
                httpClient.BaseAddress = new Uri(kkbOptions.HttpClient.Endpoint.BaseUri);
                httpClient.Timeout = TimeSpan.FromSeconds(kkbOptions.HttpClient.Timeout);
                httpClient.DefaultRequestHeaders.Clear();
            })
            .AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(GetCircuitBreakerPolicy());


        services.AddTransient<KkbClientDelegationHandler>();
        services.AddHttpClient("kkb-client")
            .ConfigureHttpClient((serviceProvider, httpClient) =>
            {
                var kkbOptions = serviceProvider.GetRequiredService<IOptions<KkbOptions>>().Value;
                httpClient.BaseAddress = new Uri(kkbOptions.HttpClient.Endpoint.BaseUri);
                httpClient.Timeout = TimeSpan.FromSeconds(kkbOptions.HttpClient.Timeout);
                httpClient.DefaultRequestHeaders.Clear();
            })
            .AddHttpMessageHandler<KkbClientDelegationHandler>()
            .AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(GetCircuitBreakerPolicy());

        return services;
    }
    private static IServiceCollection AddKapsDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        
        return services;
    }
    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy() =>
        HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy() =>
        HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));
}