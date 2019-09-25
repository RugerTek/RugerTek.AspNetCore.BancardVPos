using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class ResponseApiModel : SimpleResponseApiModel
    {
        [JsonPropertyName("process_id")]
        public string ProcessId { get; set; } = "";
    }
}