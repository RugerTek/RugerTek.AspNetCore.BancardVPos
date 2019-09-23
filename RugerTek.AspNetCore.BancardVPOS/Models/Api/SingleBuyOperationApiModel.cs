using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    public class SingleBuyOperationApiModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("shop_process_id")]
        public string ShopProcessId { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("additional_data")]
        public string AdditionalData { get; set; }
        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }
        [JsonProperty("cancel_url")]
        public string CancelUrl { get; set; }
    }
}