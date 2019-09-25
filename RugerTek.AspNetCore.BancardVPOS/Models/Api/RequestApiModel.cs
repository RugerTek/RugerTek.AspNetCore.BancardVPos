using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class RequestApiModel<T> where T : new()
    {
        [JsonPropertyName("public_key")]
        public string PublicKey { get; set; } = "";
        [JsonPropertyName("operation")]
        public T Operation { get; set; } = new T();
    }
}