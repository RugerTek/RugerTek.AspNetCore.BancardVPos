using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class ResponseApiModel
    {
        [JsonPropertyName("status"), JsonProperty("status")]
        public string Status { get; set; } = "";
        [JsonPropertyName("process_id"), JsonProperty("process_id")]
        public string? ProcessId { get; set; }
        [JsonPropertyName("messages"), JsonProperty("messages")]
        public List<MessageApiModel> Messages { get; set; } = new List<MessageApiModel>();
    }
}