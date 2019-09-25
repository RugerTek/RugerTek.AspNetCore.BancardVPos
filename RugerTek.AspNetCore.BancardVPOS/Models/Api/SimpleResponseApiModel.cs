using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class SimpleResponseApiModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
    }
}