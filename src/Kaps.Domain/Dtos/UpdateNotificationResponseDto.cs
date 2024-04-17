namespace Kaps.Domain.Dtos;

public class UpdateNotificationResponseDto
{
    public string ReferenceNumber { get; set; } // Alphanumeric, Mandatory
    public string TransactionResult { get; set; } // 1 or 0, Mandatory
    public string ErrorCode { get; set; } // Alphanumeric, 10 characters, Conditionally Mandatory
    public string ErrorDescription { get; set; } // Alphanumeric, 255 characters, Conditionally Mandatory
}