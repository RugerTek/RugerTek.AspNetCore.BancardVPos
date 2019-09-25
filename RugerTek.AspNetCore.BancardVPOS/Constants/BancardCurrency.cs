using System.Diagnostics.CodeAnalysis;

namespace RugerTek.AspNetCore.BancardVPOS.Constants
{
    public class BancardCurrency
    {
        private BancardCurrency(string value) { Value = value; }

        public string Value { get; }

        public static BancardCurrency Guarani => new BancardCurrency("PYG");
        public static BancardCurrency UsDollar => new BancardCurrency("USD");

        [return: NotNull]
        public static BancardCurrency Parse(string currency)
        {
            return currency switch
            {
                "PYG" => Guarani,
                "USD" => UsDollar,
                _ => Guarani
            };
        }
    }
}