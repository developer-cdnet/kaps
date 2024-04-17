using Kaps.Domain.Entities;

namespace Kaps.Infrastructure.Persistence;

    public interface IKapsCreateNotificationRepository
    {
        Task<Int64> AddAsync(KapsCreateNotificationEntity entity);
        Task UpdateAsync(Int64 id ,  string errorCode, string errorDescription , string activeQueryNotificationStatus ,string referenceNumber,string transactionResult);
       
    }
