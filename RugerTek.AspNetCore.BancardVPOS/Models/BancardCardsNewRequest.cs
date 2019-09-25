namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardCardsNewRequest
    {
        public int UserId { get; set; }
        public int CardId { get; set; }
        public string ReturnUrl { get; set; } = "";
        public string UserMail { get; set; } = "";
        public string UserCellPhone { get; set; } = "";
    }
}