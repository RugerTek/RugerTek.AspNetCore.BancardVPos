using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    public class UsersCardsOperationApiModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}