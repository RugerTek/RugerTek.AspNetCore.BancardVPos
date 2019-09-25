
using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class ConfirmationInfoApiModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("shop_process_id")]
        public string ShopProcessId { get; set; } = "";
        [JsonPropertyName("response")]
        public string Response { get; set; } = "";
        [JsonPropertyName("response_details")]
        public string ResponseDetails { get; set; } = "";
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "";
        [JsonPropertyName("authorization_number")]
        public string AuthorizationNumber { get; set; } = "";
        [JsonPropertyName("response_code")]
        public string ResponseCode { get; set; } = "";
        [JsonPropertyName("response_description")]
        public string ResponseDescription { get; set; } = "";
        [JsonPropertyName("extented_response_description")]
        public string ExtentedResponseDescription { get; set; } = "";
        [JsonPropertyName("security_information")]
        public SecurityInformationApiModel SecurityInformation { get; set; } = new SecurityInformationApiModel();
    }
}