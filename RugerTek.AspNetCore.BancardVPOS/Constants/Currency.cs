namespace RugerTek.AspNetCore.BancardVPOS.Constants
{
    public class Currency
    {
        private Currency(string value) { Value = value; }

        public string Value { get; }

        public static Currency Pyg => new Currency("PYG");
    }
}