using Kaps.Domain.Enums;

namespace Kaps.Domain.Dtos;

public class UpdateNotificationDto
{
     public string NotificationReferenceNumber { get; set; } // Alphanumeric, Mandatory
     public string IdentityNumber { get; set; } // Turkish Identity Number
     public string? ProductCode { get; set; } // Product code of the granted credit
     public string? CurrencyCode { get; set; } // Currency code
     public decimal? CreditAmount { get; set; } // Granted credit amount
     public DateTime? DisbursementDate { get; set; } // Disbursement date of the credit
     public TimeSpan? DisbursementTime { get; set; } // Disbursement time of the credit 
     public string UserInfo { get; set; } // User information who performed the transaction
     public decimal? IncomeInfo { get; set; } // Income information of the individual concerned
     public int InstallmentCount { get; set; } // Number of installments related to the credit transaction
     public string ChannelInfo { get; set; } // Channel information where the transaction took place

}    