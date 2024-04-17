using Kaps.Domain.Enums;

namespace Kaps.Domain.Dtos;

public class QueryDto
{
    public string IdentityNumber { get; set; } // Turkish Identity Number
    public string UserInfo { get; set; } // User information who performed the transaction
    public string? Reservation { get; set; } // Reference number of the reservation
    public decimal? ReservationAmount { get; set; } // Reference number of the reservation
    public decimal? IncomeInfo { get; set; } // Income information of the individual concerned
    public int? InstallmentCount { get; set; } // Number of installments related to the credit transaction
    public string? ChannelInfo { get; set; } // Channel information where the transaction took place
    public string? CurrencyCode { get; set; } // Currency code
    public ProductCodes? ProductCode { get; set; } // Product code of the granted credit
    public string? OrganizationCode { get; set; } // Currency code 
    public string? Application { get; set; } // Currency code  
}