using Newtonsoft.Json;

namespace Kaps.Domain.Kkb.Requests;

public class KapsQueryRequest
{
    [JsonProperty("tckn")]
    public string IdentityNumber { get; set; }  
    [JsonProperty("islemYapanKullanici")] 
    public string UserInfo { get; set; }  
    [JsonProperty("rezervasyon")] 
    public string? Reservation { get; set; }  
    [JsonProperty("rezervasyonTutari")] 
    public decimal? ReservationAmount { get; set; }  
    [JsonProperty("gelirBilgisi")] 
    public decimal? IncomeInfo { get; set; }  
    [JsonProperty("taksitSayisi")] 
    public int? InstallmentCount { get; set; }  
    [JsonProperty("kanalBilgisi")] 
    public string? ChannelInfo { get; set; }  
    [JsonProperty("dovizKodu")] 
    public string? CurrencyCode { get; set; }  
    [JsonProperty("urunKodu")] 
    public string? ProductCode { get; set; }  
    [JsonProperty("kurumKodu")] 
    public string? OrganizationCode { get; set; }  
    [JsonProperty("uygulama")] 
    public string? Application { get; set; }  
    
}