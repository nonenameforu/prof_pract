using StockExchange.Shared;

namespace StockExchange.Crypto
{
    // Сервис крипторынка: котировки и имитация движения цены
    public class CryptoMarketService
    {
        private readonly List<CryptoCurrency> _cryptos;
        private readonly List<PriceHistory> _history;
        private readonly Random _rng = new Random();

        public CryptoMarketService()
        {
            _history = new List<PriceHistory>();
            _cryptos = new List<CryptoCurrency>
            {
                new CryptoCurrency("BTC", "Bitcoin",  65000m, 1_270_000_000_000m, 28_000_000_000m),
                new CryptoCurrency("ETH", "Ethereum",  3500m,   420_000_000_000m, 14_000_000_000m),
                new CryptoCurrency("BNB", "BNB",        580m,    86_000_000_000m,  2_100_000_000m),
            };
        }

        // Имитируем волатильность ±2% (крипта волатильнее фиата)
        public void SimulateTick()
        {
            foreach (var c in _cryptos)
            {
                decimal prevRate = c.CurrentRate;
                decimal change = (decimal)(_rng.NextDouble() * 0.04 - 0.02);
                c.CurrentRate = Math.Max(0.01m, c.CurrentRate * (1 + change));
                c.ChangePercent24h = (c.CurrentRate - prevRate) / prevRate * 100;
                c.LastUpdated = DateTime.Now;
                _history.Add(new PriceHistory(c.Code, c.CurrentRate));
            }
        }

        public List<CryptoCurrency> GetAll() => _cryptos;

        public List<PriceHistory> GetHistory(string code) =>
            _history.Where(h => h.CurrencyCode == code).ToList();
    }
}