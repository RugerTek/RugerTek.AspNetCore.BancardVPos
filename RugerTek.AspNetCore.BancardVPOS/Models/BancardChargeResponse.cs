

namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardChargeResponse
    {
        public string Token { get; set; } = "";
        public int ShopProcessId { get; set; }
        public string Response { get; set; } = "N";
        public string ResponseDetails { get; set; } = "";
        public string ExtendedResponseDescription { get; set; } = "";
        public string Currency { get; set; } = "";
        public string Amount { get; set; } = "";
        public string AuthorizationNumber { get; set; } = "";
        public string TicketNumber { get; set; } = "";
        public string ResponseCode { get; set; } = "";
        public string ResponseDescription { get; set; } = "";
        public BancardSecurityInformation SecurityInformation { get; set; } = new BancardSecurityInformation();
        
        public bool IsSuccessful { get; set; }
        public BancardResponse BancardResponse { get; set; }
    }
}