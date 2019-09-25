using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardSingleBuyConfirmResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
    }
}