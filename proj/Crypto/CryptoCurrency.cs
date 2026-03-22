using StockExchange.Shared;

namespace StockExchange.Crypto
{
    // Криптовалюта: BTC, ETH, BNB и др.
    public class CryptoCurrency : Currency
    {
        public decimal MarketCap { get; set; }         // капитализация в USD
        public decimal Volume24h { get; set; }         // объём торгов за 24 часа
        public decimal ChangePercent24h { get; set; }  // изменение за 24 часа в %

        public CryptoCurrency(string code, string name, decimal rate,
                              decimal marketCap, decimal volume24h)
            : base(code, name, rate)
        {
            MarketCap = marketCap;
            Volume24h = volume24h;
        }

        public string Trend => ChangePercent24h >= 0 ? "▲" : "▼";

        public override string ToString() =>
            $"[{Code}] {Name}: {CurrentRate:F2} USD  {Trend} {ChangePercent24h:+0.00;-0.00}%";
    }
}