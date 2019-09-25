using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class MessageResponseApiModel : SimpleResponseApiModel
    {
        [JsonPropertyName("messages")]
        public List<MessageApiModel> Messages { get; set; } = new List<MessageApiModel>();
    }
}