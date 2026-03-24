using StockExchange.Shared;

namespace StockExchange.Crypto
{
    /// <summary>
    /// Сервис крипторынка. Управляет котировками криптовалют,
    /// имитирует рыночную волатильность и хранит историю изменений цен.
    /// </summary>
    public class CryptoMarketService
    {
        private readonly List<CryptoCurrency> _cryptos;
        private readonly List<PriceHistory> _history;
        private readonly Random _rng = new Random();

        /// <summary>
        /// Инициализирует сервис и заполняет список криптовалют
        /// начальными рыночными данными (BTC, ETH, BNB).
        /// </summary>
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

        /// <summary>
        /// Имитирует один тик рынка: случайно изменяет курс каждой
        /// криптовалюты в диапазоне ±2%, обновляет процентное изменение
        /// за 24 часа и сохраняет запись в историю.
        /// </summary>
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

        /// <summary>
        /// Возвращает список всех поддерживаемых криптовалют.
        /// </summary>
        /// <returns>Список объектов <see cref="CryptoCurrency"/>.</returns>
        public List<CryptoCurrency> GetAll() => _cryptos;

        /// <summary>
        /// Возвращает историю изменений курса для указанной криптовалюты.
        /// </summary>
        /// <param name="code">Тикер криптовалюты (например, "BTC").</param>
        /// <returns>Список записей <see cref="PriceHistory"/>.</returns>
        public List<PriceHistory> GetHistory(string code) =>
            _history.Where(h => h.CurrencyCode == code).ToList();
    }
}