using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class RequestApiModel<T> where T : new()
    {
        [JsonPropertyName("public_key"), JsonProperty("public_key")]
        public string PublicKey { get; set; } = "";
        [JsonPropertyName("operation"), JsonProperty("operation")]
        public T Operation { get; set; } = new T();
    }
}