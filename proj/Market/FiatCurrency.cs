using StockExchange.Shared;

namespace StockExchange.Market
{
    // Фиатная валюта: USD, RUB, CNY
    public class FiatCurrency : Currency
    {
        public string Country { get; set; }
        public string Symbol { get; set; }

        public FiatCurrency(string code, string name, string country, string symbol, decimal rate)
            : base(code, name, rate)
        {
            Country = country;
            Symbol = symbol;
        }
    }
}