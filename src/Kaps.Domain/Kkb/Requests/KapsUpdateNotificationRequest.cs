using System.Globalization;
using Kaps.Domain.Enums;
using Newtonsoft.Json;

namespace Kaps.Domain.Kkb.Requests;

public class KapsUpdateNotificationRequest
{
     [JsonProperty("bildirimReferansNumarasi")]
     public string NotificationReferenceNumber { get; set; }  
     [JsonProperty("tckn")]
     public string IdentityNumber { get; set; }  
     [JsonProperty("urunKodu")] 
     public string? ProductCode { get; set; }  
     [JsonProperty("dovizKodu")] 
     public string? CurrencyCode { get; set; }  
     [JsonProperty("krediTutari")]
     public string? CreditAmount{ get; set; }  
     [JsonProperty("kullandirimTarihi")] 
     public string? DisbursementDate{ get; set; }  
     [JsonProperty("kullandirimZamani")] 
     public string? DisbursementTime{ get; set; }   
     [JsonProperty("islemYapanKullanici")]
     public string UserInfo { get; set; } 
     [JsonProperty("gelirBilgisi")]
     public decimal? IncomeInfo { get; set; } 
     [JsonProperty("taksitSayisi")]
     public int InstallmentCount { get; set; } 
     [JsonProperty("kanalBilgisi")]
     public string ChannelInfo { get; set; } 

}