using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class SingleBuyOperationApiModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("shop_process_id")]
        public string ShopProcessId { get; set; } = "";
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "";
        [JsonPropertyName("amount")]
        public string Amount { get; set; }
        [JsonPropertyName("additional_data")]
        public string AdditionalData { get; set; } = "";
        [JsonPropertyName("return_url")]
        public string ReturnUrl { get; set; } = "";
        [JsonPropertyName("cancel_url")]
        public string CancelUrl { get; set; } = "";
    }
}