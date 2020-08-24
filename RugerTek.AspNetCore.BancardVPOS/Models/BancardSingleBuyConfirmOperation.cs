using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardSingleBuyConfirmOperation
    {
        [JsonPropertyName("token"), JsonProperty("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("shop_process_id"), JsonProperty("shop_process_id")]
        public int ShopProcessId { get; set; }
        [JsonPropertyName("response"), JsonProperty("response")]
        public string Response { get; set; } = "";
        [JsonPropertyName("response_details"), JsonProperty("response_details")]
        public string ResponseDetails { get; set; } = "";
        [JsonPropertyName("amount"), JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonPropertyName("currency"), JsonProperty("currency")]
        public string Currency { get; set; } = "";
        [JsonPropertyName("authorization_number"), JsonProperty("authorization_number")]
        public string AuthorizationNumber { get; set; } = "";
        [JsonPropertyName("response_code"), JsonProperty("response_code")]
        public string ResponseCode { get; set; } = "";
        [JsonPropertyName("response_description"), JsonProperty("response_description")]
        public string ResponseDescription { get; set; } = "";
        [JsonPropertyName("extended_response_description"), JsonProperty("extended_response_description")]
        public string? ExtendedResponseDescription { get; set; }
        [JsonPropertyName("security_information"), JsonProperty("security_information")]
        public BancardSecurityInformation SecurityInformation { get; set; } = new BancardSecurityInformation();
    }
}