using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    public class CardApiModel
    {
        [JsonPropertyName("expiration_date")]
        public string ExpirationDate { get; set; } = "";
        [JsonPropertyName("card_brand")]
        public string CardBrand { get; set; } = "";
        [JsonPropertyName("card_id")]
        public int CardId { get; set; }
        [JsonPropertyName("card_type")]
        public string CardType { get; set; } = "";
        [JsonPropertyName("alias_token")]
        public string AliasToken { get; set; } = "";
        [JsonPropertyName("card_masked_number")]
        public string CardMaskedNumber { get; set; } = "";
    }
}