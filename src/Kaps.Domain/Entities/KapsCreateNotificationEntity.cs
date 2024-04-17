using Kaps.Domain.Entities.Base;

namespace Kaps.Domain.Entities;

public class KapsCreateNotificationEntity:IEntity
{
    public string IdentityNumber { get; set; }  
    public string ProductCode { get; set; }  
    public string CurrencyCode { get; set; } 
    public string CreditAmount{ get;set;}
    public string DisbursementDate{ get;set;}
    public string DisbursementTime{get;set;} 
    public string? ReservationReferenceNumber { get; set; } 
    public string UserInfo { get; set; } 
    public decimal? IncomeInfo { get; set; } 
    public int InstallmentCount { get; set; } 
    public string ChannelInfo { get; set; }
    public string? ReferenceNumber { get; set; }
    public string? TransactionResult { get; set; }
    public string? ErrorCode { get; set; }
    public string? ErrorDescription { get; set; } 
    public string? ActiveQueryNotificationStatus { get; set; }

    public string UserName { get; set; }
    public string HostName { get; set; }
    public DateTime SystemDate { get; set; }
   
}
 