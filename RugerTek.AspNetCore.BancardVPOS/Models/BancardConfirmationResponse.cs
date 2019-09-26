namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardConfirmationResponse : BancardResponse
    {
        public BancardConfirmationInfo Confirmation { get; set; } = new BancardConfirmationInfo();
    }
}