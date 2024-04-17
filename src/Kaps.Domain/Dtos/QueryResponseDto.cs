namespace Kaps.Domain.Dtos;

public class QueryResponseDto
{
    public string ReferenceNumber { get; set; }
    public string ReservationReferenceNumber { get; set; }
    public string TransactionResult { get; set; }
    public string ErrorCode { get; set; }
    public string ErrorDescription { get; set; }
    public List<UsageInformationDto> UsageInformationList { get; set; }
}

public class UsageInformationDto
{
    public string ProductCode { get; set; }
    public string CurrencyCode { get; set; }
    public decimal? UsageAmount { get; set; }
    public string Status { get; set; }
    public DateTime TransactionDate { get; set; }
    public TimeSpan TransactionTime { get; set; }
    public string MemberCode { get; set; }
    public decimal? IncomeInfo { get; set; }
    public int? InstallmentCount { get; set; }
    public string? ChannelInfo { get; set; }
}