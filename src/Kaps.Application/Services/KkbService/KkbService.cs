using Kaps.Domain.Entities;
using Kaps.Domain.Kkb.Requests;
using Kaps.Domain.Kkb.Responses;
using Kaps.Infrastructure.KkbIntegration;
using Kaps.Infrastructure.Persistence;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Kaps.Application.Services.KkbService;

public class KkbService : IKkbService
{
    private readonly IKkbClient _kkbClient; 
    private readonly ILogger<KkbService> _logger;
    private readonly IKapsCreateNotificationRepository _createNotificationRepository;
  

    public KkbService(IKkbClient kkbClient, ILogger<KkbService> logger, IKapsCreateNotificationRepository createNotificationRepository)
    {
        _kkbClient = kkbClient;  
        _logger = logger;
        _createNotificationRepository = createNotificationRepository;
    }
    public async Task<KkbCreateNotificationResponse?> CreateNotification(KapsCreateNotificationRequest request, CancellationToken cancellationToken = default)
    {
        var entity = request.Adapt<KapsCreateNotificationEntity>();
        var id = await _createNotificationRepository.AddAsync(entity);
        var response = await _kkbClient.CreateNotificationAsync(request, cancellationToken);
        if (response == null)
        {
            _logger.LogInformation($"response null for {@request}");
            return response;
        }
        await _createNotificationRepository.UpdateAsync(id,response.ErrorCode,response.ErrorDescription,response.ActiveQueryNotificationStatus, response.ReferenceNumber,response.TransactionResult);
        return response;
    }

  
}