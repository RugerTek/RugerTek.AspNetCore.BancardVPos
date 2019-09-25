using System.Text.Json.Serialization;

namespace RugerTek.AspNetCore.BancardVPOS.Models.Api
{
    internal class CardsNewOperationApiModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; } = "";
        [JsonPropertyName("card_id")]
        public int CardId { get; set; }
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        [JsonPropertyName("user_cell_phone")]
        public string UserCellPhone { get; set; } = "";
        [JsonPropertyName("user_mail")]
        public string UserMail { get; set; } = "";
        [JsonPropertyName("return_url")]
        public string ReturnUrl { get; set; } = "";
    }
}