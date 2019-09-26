using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class ResponseApiModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
        [JsonPropertyName("process_id")]
        public string? ProcessId { get; set; }
        [JsonPropertyName("messages")]
        public List<MessageApiModel> Messages { get; set; } = new List<MessageApiModel>();
    }
}