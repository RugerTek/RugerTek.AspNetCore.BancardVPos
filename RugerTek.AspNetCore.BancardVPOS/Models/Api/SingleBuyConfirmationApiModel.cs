using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    public class SingleBuyConfirmationApiModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("shop_process_id")]
        public string ShopProcessId { get; set; }
    }
}