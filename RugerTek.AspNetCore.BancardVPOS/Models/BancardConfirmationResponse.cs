namespace RugerTek.AspNetCore.BancardVPOS.Models
{
    public class BancardConfirmationResponse : BancardMessageResponse
    {
        public BancardConfirmationInfo Confirmation { get; set; } = new BancardConfirmationInfo();
    }
}