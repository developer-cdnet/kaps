using Kaps.Domain.Entities.Base;

namespace Kaps.Domain.Entities;

public class KapsUsageInformationEntity:IEntity
{
    public long KkbQueryId { get; set; }
    public string ProductCode { get; set; } 
    public string CurrencyCode { get; set; } 
    public string UsageAmount { get; set; }
    public string Status { get; set; }
    public string TransactionDate { get; set; }
    public string TransactionTime { get; set; }
    public string MemberCode { get; set; }
    public decimal? IncomeInfo { get; set; }
    public int? InstallmentCount { get; set; }
    public string? ChannelInfo { get; set; }
}