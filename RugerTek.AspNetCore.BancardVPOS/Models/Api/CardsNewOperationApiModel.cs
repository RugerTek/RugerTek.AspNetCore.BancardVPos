using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class CardsNewOperationApiModel
    {
        [JsonPropertyName("token"), JsonProperty("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("card_id"), JsonProperty("card_id")]
        public int CardId { get; set; }
        [JsonPropertyName("user_id"), JsonProperty("user_id")]
        public int UserId { get; set; }
        [JsonPropertyName("user_cell_phone"), JsonProperty("user_cell_phone")]
        public string UserCellPhone { get; set; } = "";
        [JsonPropertyName("user_mail"), JsonProperty("user_mail")]
        public string UserMail { get; set; } = "";
        [JsonPropertyName("return_url"), JsonProperty("return_url")]
        public string ReturnUrl { get; set; } = "";
    }
}