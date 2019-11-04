
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class DeleteOperationApiModel
    {
        [JsonPropertyName("token"), JsonProperty("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("alias_token"), JsonProperty("alias_token")]
        public string AliasToken { get; set; } = "";
    }
}