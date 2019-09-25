using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class ChargeOperationApiModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("shop_process_id")]
        public string ShopProcessId { get; set; } = "";
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
        [JsonPropertyName("number_of_payments")]
        public int NumberOfPayments { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "";
        [JsonPropertyName("additional_data")]
        public string AdditionalData { get; set; } = "";
        [JsonPropertyName("description")]
        public string Description { get; set; } = "";
        [JsonPropertyName("alias_token")]
        public string AliasToken { get; set; } = "";
    }
}