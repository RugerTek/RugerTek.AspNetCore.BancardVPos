using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class OperationResponseApiModel<T>
    {
        [JsonPropertyName("operation"), JsonProperty("operation")]
        public T Operation { get; set; }
    }
}