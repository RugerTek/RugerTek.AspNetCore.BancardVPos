using System.Collections.Generic;

namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardUserCardsResponse : BancardResponse
    {
        public List<BancardCard> Cards { get; set; } = new List<BancardCard>();
    }
}