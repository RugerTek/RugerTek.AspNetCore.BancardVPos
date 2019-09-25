
using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class DeleteOperationApiModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("alias_token")]
        public string AliasToken { get; set; } = "";
    }
}