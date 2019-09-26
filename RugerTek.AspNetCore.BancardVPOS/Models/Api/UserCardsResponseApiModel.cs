using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class UserCardsResponseApiModel : ResponseApiModel
    {
        [JsonPropertyName("cards")]
        public List<CardApiModel> Cards { get; set; } = new List<CardApiModel>();
    }
}