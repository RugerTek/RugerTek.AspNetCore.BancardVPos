namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardResponse
    {
        public bool IsSuccessStatusCode { get; set; }
        public string Status { get; set; }
        public string ProcessId { get; set; }
    }
}