using StockExchange.Shared;

namespace StockExchange.Market
{
    /// <summary>
    /// Сервис управления курсами фиатных валют (USD, RUB, CNY).
    /// Обеспечивает имитацию рыночных колебаний, конвертацию сумм
    /// и хранение истории курсов.
    /// </summary>
    public class ExchangeRateService
    {
        private readonly List<FiatCurrency> _currencies;
        private readonly List<PriceHistory> _history;
        private readonly Random _rng = new Random();

        /// <summary>
        /// Инициализирует сервис и заполняет список валют начальными курсами.
        /// </summary>
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

        /// <summary>
        /// Имитирует один тик рынка: случайно изменяет курс каждой валюты
        /// в диапазоне ±0.5% и сохраняет новое значение в историю.
        /// USD остаётся неизменным (базовая валюта).
        /// </summary>
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

        /// <summary>
        /// Возвращает список всех поддерживаемых фиатных валют.
        /// </summary>
        /// <returns>Список объектов <see cref="FiatCurrency"/>.</returns>
        public List<FiatCurrency> GetAll() => _currencies;

        /// <summary>
        /// Конвертирует указанную сумму из одной валюты в другую
        /// по текущим курсам.
        /// </summary>
        /// <param name="fromCode">Код исходной валюты.</param>
        /// <param name="toCode">Код целевой валюты.</param>
        /// <param name="amount">Сумма для конвертации.</param>
        /// <returns>Сконвертированная сумма в целевой валюте.</returns>
        public decimal Convert(string fromCode, string toCode, decimal amount)
        {
            var from = _currencies.First(c => c.Code == fromCode);
            var to = _currencies.First(c => c.Code == toCode);
            return amount * from.CurrentRate / to.CurrentRate;
        }

        /// <summary>
        /// Возвращает историю изменений курса для указанной валюты.
        /// </summary>
        /// <param name="code">Код валюты.</param>
        /// <returns>Список записей <see cref="PriceHistory"/>.</returns>
        public List<PriceHistory> GetHistory(string code) =>
            _history.Where(h => h.CurrencyCode == code).ToList();
    }
}