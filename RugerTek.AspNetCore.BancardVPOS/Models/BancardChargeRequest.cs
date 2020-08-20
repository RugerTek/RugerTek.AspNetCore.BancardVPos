using RugerTek.AspNetCore.BancardVPOS.Constants;

namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardChargeRequest
    {
        public int ShopProcessId { get; set; }
        public double Amount { get; set; }
        public int NumberOfPayments { get; set; }
        public BancardCurrency Currency { get; set; } = BancardCurrency.Guarani;
        public string AdditionalData { get; set; } = "";
        public string Description { get; set; } = "";
        public string AliasToken { get; set; } = "";
    }
}