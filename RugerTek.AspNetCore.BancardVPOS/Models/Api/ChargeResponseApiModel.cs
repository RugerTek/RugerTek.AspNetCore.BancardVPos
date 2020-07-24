using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class ChargeResponseApiModel
    {
        [JsonPropertyName("operation"), JsonProperty("operation")]
        public ChargeOperationResponseApiModel Operation { get; set; } = new ChargeOperationResponseApiModel();
    }
}