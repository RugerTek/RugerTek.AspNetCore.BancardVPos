using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class SingleBuyOperationApiModel
    {
        [JsonPropertyName("token"), JsonProperty("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("description"), JsonProperty("description")]
        public string Description { get; set; } = "";
        [JsonPropertyName("shop_process_id"), JsonProperty("shop_process_id")]
        public string ShopProcessId { get; set; } = "";
        [JsonPropertyName("currency"), JsonProperty("currency")]
        public string Currency { get; set; } = "";

        [JsonPropertyName("amount"), JsonProperty("amount")] 
        public decimal Amount { get; set; }
        [JsonPropertyName("additional_data"), JsonProperty("additional_data")]
        public string? AdditionalData { get; set; }
        [JsonPropertyName("return_url"), JsonProperty("return_url")]
        public string ReturnUrl { get; set; } = "";
        [JsonPropertyName("cancel_url"), JsonProperty("cancel_url")]
        public string CancelUrl { get; set; } = "";
    }
}