using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class CardApiModel
    {
        [JsonPropertyName("expiration_date"), JsonProperty("expiration_date")]
        public string ExpirationDate { get; set; } = "";
        [JsonPropertyName("card_brand"), JsonProperty("card_brand")]
        public string CardBrand { get; set; } = "";
        [JsonPropertyName("card_id"), JsonProperty("card_id")]
        public int CardId { get; set; }
        [JsonPropertyName("card_type"), JsonProperty("card_type")]
        public string CardType { get; set; } = "";
        [JsonPropertyName("alias_token"), JsonProperty("alias_token")]
        public string AliasToken { get; set; } = "";
        [JsonPropertyName("card_masked_number"), JsonProperty("card_masked_number")]
        public string CardMaskedNumber { get; set; } = "";
    }
}