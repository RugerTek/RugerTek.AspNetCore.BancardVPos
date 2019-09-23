using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    public class CardsNewOperationApiModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("card_id")]
        public string CardId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("user_cell_phone")]
        public string UserCellPhone { get; set; }
        [JsonProperty("user_mail")]
        public string UserMail { get; set; }
        [JsonProperty("return_url")]
        public string ReturnUrl { get; set; }
    }
}