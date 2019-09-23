using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    public class BancardRequestApiModel<T>
    {
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }
        [JsonProperty("operation")]
        public T Operation { get; set; }
    }
}