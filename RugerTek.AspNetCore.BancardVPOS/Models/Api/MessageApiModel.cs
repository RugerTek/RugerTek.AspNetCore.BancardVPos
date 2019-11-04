using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class MessageApiModel
    {
        [JsonPropertyName("key"), JsonProperty("key")]
        public string Key { get; set; } = "";
        [JsonPropertyName("level"), JsonProperty("level")]
        public string Level { get; set; } = "";
        [JsonPropertyName("dsc"), JsonProperty("dsc")]
        public string Dsc { get; set; } = "";
    }
}