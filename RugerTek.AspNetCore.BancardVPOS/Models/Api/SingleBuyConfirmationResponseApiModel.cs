using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class SingleBuyConfirmationResponseApiModel : MessageResponseApiModel
    {
        [JsonPropertyName("confirmation")]
        public ConfirmationInfoApiModel Confirmation { get; set; } = new ConfirmationInfoApiModel();
    }
}