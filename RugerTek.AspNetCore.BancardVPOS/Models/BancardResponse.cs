using System.Collections.Generic;

namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardResponse
    {
        public string? ProcessId { get; set; }
        public List<BancardMessage> Messages { get; set; } = new List<BancardMessage>();
        public bool IsSuccessStatusCode { get; set; }
        public string Status { get; set; } = "";
    }
}