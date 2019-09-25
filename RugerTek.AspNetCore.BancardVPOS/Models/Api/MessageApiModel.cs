using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class MessageApiModel
    {
        [JsonPropertyName("Key")]
        public string Key { get; set; } = "";
        [JsonPropertyName("Level")]
        public string Level { get; set; } = "";
        [JsonPropertyName("Dsc")]
        public string Dsc { get; set; } = "";
    }
}