using Kaps.Domain.Dtos;
using Kaps.Domain.Kkb.Requests;
using Kaps.Domain.Kkb.Responses;

namespace Kaps.Application.Services.KkbService;

public interface IKkbService
{

    Task<KkbCreateNotificationResponse?> CreateNotification(KapsCreateNotificationRequest request, CancellationToken cancellationToken=default);
    

}   