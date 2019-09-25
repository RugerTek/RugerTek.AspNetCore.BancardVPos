using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class SecurityInformationApiModel
    {
        [JsonPropertyName("card_source")]
        public string CardSource { get; set; } = "";
        [JsonPropertyName("customer_ip")]
        public string CustomerIp { get; set; } = "";
        [JsonPropertyName("card_country")]
        public string CardCountry { get; set; } = "";
        [JsonPropertyName("version")]
        public string Version { get; set; } = "";
        [JsonPropertyName("risk_index")]
        public string RiskIndex { get; set; } = "";
    }
}