using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class SingleBuyConfirmationApiModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("shop_process_id")]
        public string ShopProcessId { get; set; } = "";
    }
}