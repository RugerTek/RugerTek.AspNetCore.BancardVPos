using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class UsersCardsOperationApiModel
    {
        [JsonPropertyName("token"), JsonProperty("token")]
        public string Token { get; set; } = "";
    }
}