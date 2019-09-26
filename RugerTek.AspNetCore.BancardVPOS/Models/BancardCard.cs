namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardCard
    {
        public string ExpirationDate { get; set; } = "";
        public string CardBrand { get; set; } = "";
        public int CardId { get; set; }
        public string CardType { get; set; } = "";
        public string AliasToken { get; set; } = "";
        public string CardMaskedNumber { get; set; } = "";
    }
}