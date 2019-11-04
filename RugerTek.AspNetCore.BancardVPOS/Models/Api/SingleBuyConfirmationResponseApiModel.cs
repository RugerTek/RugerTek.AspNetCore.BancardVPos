using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class SingleBuyConfirmationResponseApiModel : ResponseApiModel
    {
        [JsonPropertyName("confirmation"), JsonProperty("confirmation")]
        public ConfirmationInfoApiModel Confirmation { get; set; } = new ConfirmationInfoApiModel();
    }
}