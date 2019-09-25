using System.Collections.Generic;

namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardMessageResponse : BancardSimpleResponse
    {
        public List<BancardMessage> Messages { get; set; } = new List<BancardMessage>();
    }
}