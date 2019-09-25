namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardSingleBuyConfirmOperation
    {
        public string Token { get; set; } = "";
        public string ShopProcessId { get; set; } = "";
        public string Response { get; set; } = "";
        public string ResponseDetails { get; set; } = "";
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "";
        public string AuthorizationNumber { get; set; } = "";
        public string ResponseCode { get; set; } = "";
        public string ResponseDescription { get; set; } = "";
        public string ExtentedResponseDescription { get; set; } = "";
        public BancardSecurityInformation SecurityInformation { get; set; } = new BancardSecurityInformation();
    }
}