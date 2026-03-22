using StockExchange.Shared;

namespace StockExchange.Market
{
    // Сервис обменных курсов фиатных валют
    public class ExchangeRateService
    {
        private readonly List<FiatCurrency> _currencies;
        private readonly List<PriceHistory> _history;
        private readonly Random _rng = new Random();

        public ExchangeRateService()
        {
            _history = new List<PriceHistory>();
            _currencies = new List<FiatCurrency>
            {
                new FiatCurrency("USD", "US Dollar",     "США",    "$", 1.0000m),
                new FiatCurrency("RUB", "Russian Ruble", "Россия", "₽", 0.0110m),
                new FiatCurrency("CNY", "Chinese Yuan",  "Китай",  "¥", 0.1380m),
            };
        }

        // Имитируем колебание курса ±0.5%
        public void SimulateTick()
        {
            foreach (var c in _currencies)
            {
                if (c.Code == "USD") continue;
                decimal change = (decimal)(_rng.NextDouble() * 0.01 - 0.005);
                c.CurrentRate = Math.Max(0.0001m, c.CurrentRate * (1 + change));
                c.LastUpdated = DateTime.Now;
                _history.Add(new PriceHistory(c.Code, c.CurrentRate));
            }
        }

        public List<FiatCurrency> GetAll() => _currencies;

        public decimal Convert(string fromCode, string toCode, decimal amount)
        {
            var from = _currencies.First(c => c.Code == fromCode);
            var to = _currencies.First(c => c.Code == toCode);
            return amount * from.CurrentRate / to.CurrentRate;
        }

        public List<PriceHistory> GetHistory(string code) =>
            _history.Where(h => h.CurrencyCode == code).ToList();
    }
}