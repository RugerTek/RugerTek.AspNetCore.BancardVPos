using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardSingleBuyConfirm
    {
        [JsonPropertyName("operation")]
        public BancardSingleBuyConfirmOperation Operation { get; set; } = new BancardSingleBuyConfirmOperation();
    }
}