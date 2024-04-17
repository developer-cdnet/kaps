using Newtonsoft.Json;

namespace Kaps.Domain.Kkb.Models;

public class KkbTokenModel
{
    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("scope")]
    public string Scope { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("consented_on")]
    public int ConsentedOn { get; set; }
}