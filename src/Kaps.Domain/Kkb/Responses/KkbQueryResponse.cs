using Newtonsoft.Json;

namespace Kaps.Domain.Kkb.Responses;

public class KkbQueryResponse
{
     
    [JsonProperty("referansNumarasi")]
    public string ReferenceNumber { get; set; }
    [JsonProperty("rezervasyonReferansNumarasi")]
    public string ReservationReferenceNumber { get; set; }
    [JsonProperty("islemSonucu")]
    public string TransactionResult { get; set; }
    [JsonProperty("hataKodu")]
    public string ErrorCode { get; set; }
    [JsonProperty("hataAciklama")]
    public string ErrorDescription { get; set; }
    [JsonProperty("kullandirimListe")]
    public List<KkbUsageInformationModel> UsageInformationList { get; set; }
}

public class KkbUsageInformationModel
{
    [JsonProperty("urunKodu")]
    public string ProductCode { get; set; }
    [JsonProperty("dovizKodu")]
    public string CurrencyCode { get; set; }
    [JsonProperty("kullandirimTutari")]
    public string UsageAmount { get; set; }
    [JsonProperty("statu")]
    public string Status { get; set; }
    [JsonProperty("islemTarihi")]
    public string TransactionDate { get; set; }
    [JsonProperty("islemZamani")]
    public string TransactionTime { get; set; }
    [JsonProperty("uyeKodu")]
    public string MemberCode { get; set; }
    [JsonProperty("gelirBilgisi")]
    public decimal? IncomeInfo { get; set; }
    [JsonProperty("taksitSayisi")]
    public int? InstallmentCount { get; set; }
    [JsonProperty("kanalBilgisi")]
    public string? ChannelInfo { get; set; }
}