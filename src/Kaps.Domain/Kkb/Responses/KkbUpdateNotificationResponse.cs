using Newtonsoft.Json;

namespace Kaps.Domain.Kkb.Responses;

public class KkbUpdateNotificationResponse
{
    [JsonProperty("referansNumarasi")]
    public string ReferenceNumber { get; set; }
    [JsonProperty("islemSonucu")]
    public string TransactionResult { get; set; }
    [JsonProperty("hataKodu")]
    public string? ErrorCode { get; set; }
    [JsonProperty("hataAciklama")]
    public string? ErrorDescription { get; set; } 
    
   
}