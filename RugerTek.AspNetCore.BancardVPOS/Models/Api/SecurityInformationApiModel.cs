using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class SecurityInformationApiModel
    {
        [JsonPropertyName("card_source"), JsonProperty("card_source")]
        public string CardSource { get; set; } = "";
        [JsonPropertyName("customer_ip"), JsonProperty("customer_ip")]
        public string CustomerIp { get; set; } = "";
        [JsonPropertyName("card_country"), JsonProperty("card_country")]
        public string CardCountry { get; set; } = "";
        [JsonPropertyName("version"), JsonProperty("version")]
        public string Version { get; set; } = "";
        [JsonPropertyName("risk_index"), JsonProperty("risk_index")]
        public int RiskIndex { get; set; }
    }
}