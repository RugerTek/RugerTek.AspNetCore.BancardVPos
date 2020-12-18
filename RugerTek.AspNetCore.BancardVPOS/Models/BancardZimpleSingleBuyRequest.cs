using RugerTek.AspNetCore.BancardVPOS.Constants;

namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardZimpleSingleBuyRequest
    {
        public int ShopProcessId { get; set; }
        public BancardCurrency Currency { get; set; } = BancardCurrency.Guarani;
        public double Amount { get; set; }
        public string AdditionalData { get; set; }
        public string Description { get; set; } = "";
        public string ReturnUrl { get; set; } = "";
        public string CancelUrl { get; set; } = "";
        public string Zimple { get; set; } = "";
    }
}