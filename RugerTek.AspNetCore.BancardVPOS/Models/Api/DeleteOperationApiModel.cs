using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    public class DeleteOperationApiModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("alias_token")]
        public string AliasToken { get; set; }
    }
}