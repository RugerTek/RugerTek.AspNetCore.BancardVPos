using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class ChargeOperationApiModel
    {
        [JsonPropertyName("token"), JsonProperty("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("shop_process_id"), JsonProperty("shop_process_id")]
        public int ShopProcessId { get; set; }
        [JsonPropertyName("amount"), JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonPropertyName("number_of_payments"), JsonProperty("number_of_payments")]
        public int NumberOfPayments { get; set; }
        [JsonPropertyName("currency"), JsonProperty("currency")]
        public string Currency { get; set; } = "";

        [JsonPropertyName("additional_data"), JsonProperty("additional_data")] 
        public string AdditionalData { get; set; } = "";
        [JsonPropertyName("description"), JsonProperty("description")]
        public string Description { get; set; } = "";
        [JsonPropertyName("alias_token"), JsonProperty("alias_token")]
        public string AliasToken { get; set; } = "";
    }
}