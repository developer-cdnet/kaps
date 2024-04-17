using Kaps.Domain.Entities.Base;

namespace Kaps.Domain.Entities;

public class KapsQueryEntity:IEntity
{
    public string IdentityNumber { get; set; }  
    public string UserInfo { get; set; }  
    public string? Reservation { get; set; }  
    public decimal? ReservationAmount { get; set; }  
    public decimal? IncomeInfo { get; set; }  
    public int? InstallmentCount { get; set; }  
    public string? ChannelInfo { get; set; }  
    public string? CurrencyCode { get; set; }  
    public string? ProductCode { get; set; }  
    public string? OrganizationCode { get; set; }  
    public string? Application { get; set; }  
    public string ReferenceNumber { get; set; }
    public string ReservationReferenceNumber { get; set; }
    public string TransactionResult { get; set; }
    public string ErrorCode { get; set; }
    public string ErrorDescription { get; set; }
   
    public ICollection<KapsUsageInformationEntity>? UsageInformationList { get; set; }
   
}