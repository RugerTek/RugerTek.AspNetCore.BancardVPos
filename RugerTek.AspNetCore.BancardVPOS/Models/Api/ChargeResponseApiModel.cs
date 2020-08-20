using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class ChargeResponseApiModel
    {
        [JsonPropertyName("status"), JsonProperty("status")]
        public string Status { get; set; }
        [JsonPropertyName("confirmation"), JsonProperty("confirmation")]
        public ChargeOperationResponseApiModel Confirmation { get; set; } = new ChargeOperationResponseApiModel();
    }
}