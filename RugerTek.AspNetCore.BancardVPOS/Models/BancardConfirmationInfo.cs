using RugerTek.AspNetCore.BancardVPOS.Constants;

namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardConfirmationInfo
    {
        public string Token { get; set; } = "";
        public int ShopProcessId { get; set; }
        public string Response { get; set; } = "";
        public string ResponseDetails { get; set; } = "";
        public string Amount { get; set; }
        public BancardCurrency Currency { get; set; } = BancardCurrency.Guarani;
        public string AuthorizationNumber { get; set; } = "";
        public string ResponseCode { get; set; } = "";
        public string ResponseDescription { get; set; } = "";
        public string ExtentedResponseDescription { get; set; } = "";
        public BancardSecurityInformation SecurityInformation { get; set; } = new BancardSecurityInformation();
    }
}