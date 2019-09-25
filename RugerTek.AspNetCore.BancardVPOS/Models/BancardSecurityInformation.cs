namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardSecurityInformation
    {
        public string CardSource { get; set; } = "";
        public string CustomerIp { get; set; } = "";
        public string CardCountry { get; set; } = "";
        public string Version { get; set; } = "";
        public string RiskIndex { get; set; } = "";
    }
}