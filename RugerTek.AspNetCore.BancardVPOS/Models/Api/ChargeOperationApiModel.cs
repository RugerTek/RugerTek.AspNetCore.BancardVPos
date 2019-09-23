using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    public class ChargeOperationApiModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("shop_process_id")]
        public string ShopProcessId { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("number_of_payments")]
        public string NumberOfPayments { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("additional_data")]
        public string AdditionalData { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("alias_token")]
        public string AliasToken { get; set; }
    }
}