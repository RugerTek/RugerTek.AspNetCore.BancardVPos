using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class UsersCardsOperationApiModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = "";
    }
}