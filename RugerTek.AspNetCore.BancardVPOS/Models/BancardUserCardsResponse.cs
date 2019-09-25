using System.Collections.Generic;

namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardUserCardsResponse : BancardSimpleResponse
    {
        public List<BancardCard> Cards { get; set; } = new List<BancardCard>();
    }
}