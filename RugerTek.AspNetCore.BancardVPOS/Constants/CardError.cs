using System.Collections.Generic;

namespace RugerTek.AspNetCore.BancardVPOS.Constants
{
    public class CardError
    {
        private static readonly IReadOnlyDictionary<string, string> Messages = new Dictionary<string, string>
        {
            ["CardAlreadyRegisteredByUserError"] = "The user has already registered the card.",
            ["InvalidCiError"] = "The user's ci does not match with card's ci.",
            ["CardRequestAlreadyProcessedError"] = "The card request with process id #{@process_id} has already been processed.",
            ["CardInvalidDataError"] = "The data for the card is not correct",
            ["NewCardRequestNotFoundError"] = "New card request not found for process id: #{@process_id}.",
            ["CardNotFoundError"] = "The card does not exist.",
            ["CardAliasTokenExpiredError"] = "The card alias token has expired.",
            ["CardBlockedError"] = "The card for the user is blocked.",
            ["InvalidCardStatus "] = "The given status is incorrect.",
        };
        
        private CardError(string code)
        {
            Code = code; 
            Message = Messages[code];
        }

        public string Code { get; }
        public string Message { get; }

        public static CardError CardAlreadyRegisteredByUserError => new CardError("CardAlreadyRegisteredByUserError");
        public static CardError InvalidCiError => new CardError("InvalidCiError");
        public static CardError CardRequestAlreadyProcessedError => new CardError("CardRequestAlreadyProcessedError");
        public static CardError CardInvalidDataError => new CardError("CardInvalidDataError");
        public static CardError NewCardRequestNotFoundError => new CardError("NewCardRequestNotFoundError");
        public static CardError CardNotFoundError => new CardError("CardNotFoundError");
        public static CardError CardAliasTokenExpiredError => new CardError("CardAliasTokenExpiredError");
        public static CardError CardBlockedError => new CardError("CardBlockedError");
        public static CardError InvalidCardStatus => new CardError("InvalidCardStatus");
    }
}