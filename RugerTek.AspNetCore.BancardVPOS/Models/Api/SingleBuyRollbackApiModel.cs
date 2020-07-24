using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class SingleBuyRollbackApiModel
    {
        [JsonPropertyName("token"), JsonProperty("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("shop_process_id"), JsonProperty("shop_process_id")]
        public string ShopProcessId { get; set; } = "";
    }
}