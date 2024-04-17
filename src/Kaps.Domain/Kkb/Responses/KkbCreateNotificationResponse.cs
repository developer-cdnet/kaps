using Newtonsoft.Json;

namespace Kaps.Domain.Kkb.Responses;

public class KkbCreateNotificationResponse
{
    [JsonProperty("referansNumarasi")]
    public string ReferenceNumber { get; set; }
    [JsonProperty("islemSonucu")]
    public string TransactionResult { get; set; }
    [JsonProperty("hataKodu")]
    public string? ErrorCode { get; set; }
    [JsonProperty("hataAciklama")]
    public string? ErrorDescription { get; set; } 
    [JsonProperty("aktifSorguBildirimDurumu")]
    public string ActiveQueryNotificationStatus { get; set; }
 
    
   
}