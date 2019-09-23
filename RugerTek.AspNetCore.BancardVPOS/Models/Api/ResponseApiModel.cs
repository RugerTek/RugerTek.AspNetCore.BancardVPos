using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    public class ResponseApiModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("process_id")]
        public string ProcessId { get; set; }
    }
}