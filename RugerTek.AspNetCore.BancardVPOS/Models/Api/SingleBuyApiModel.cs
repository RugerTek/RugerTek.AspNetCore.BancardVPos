using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class SingleBuyApiModel
    {
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }
        [JsonProperty("operation")]
        public OperationApiModel Operation { get; set; } = new OperationApiModel();
    }
}