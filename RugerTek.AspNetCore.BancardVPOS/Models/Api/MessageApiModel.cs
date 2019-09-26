using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class MessageApiModel
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = "";
        [JsonPropertyName("level")]
        public string Level { get; set; } = "";
        [JsonPropertyName("dsc")]
        public string Dsc { get; set; } = "";
    }
}