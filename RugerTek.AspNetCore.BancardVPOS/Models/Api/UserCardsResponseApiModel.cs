using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class UserCardsResponseApiModel : ResponseApiModel
    {
        [JsonPropertyName("cards"), JsonProperty("cards")]
        public List<CardApiModel> Cards { get; set; } = new List<CardApiModel>();
    }
}