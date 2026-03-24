using StockExchange.Shared;

namespace StockExchange.Crypto
{
    /// <summary>
    /// Представляет криптовалюту (BTC, ETH, BNB и др.).
    /// Расширяет базовую модель <see cref="Currency"/> рыночными
    /// показателями: капитализацией, объёмом торгов и изменением за 24 часа.
    /// </summary>
    public class CryptoCurrency : Currency
    {
        /// <summary>Рыночная капитализация в долларах США.</summary>
        public decimal MarketCap { get; set; }

        /// <summary>Объём торгов за последние 24 часа в долларах США.</summary>
        public decimal Volume24h { get; set; }

        /// <summary>Процентное изменение курса за последние 24 часа.</summary>
        public decimal ChangePercent24h { get; set; }

        /// <summary>
        /// Возвращает символ тренда: ▲ при росте, ▼ при падении.
        /// </summary>
        public string Trend => ChangePercent24h >= 0 ? "▲" : "▼";

        /// <summary>
        /// Инициализирует новый экземпляр криптовалюты.
        /// </summary>
        /// <param name="code">Тикер криптовалюты (например, "BTC").</param>
        /// <param name="name">Полное название (например, "Bitcoin").</param>
        /// <param name="rate">Начальный курс в USD.</param>
        /// <param name="marketCap">Рыночная капитализация в USD.</param>
        /// <param name="volume24h">Объём торгов за 24 часа в USD.</param>
        public CryptoCurrency(string code, string name, decimal rate,
                              decimal marketCap, decimal volume24h)
            : base(code, name, rate)
        {
            MarketCap = marketCap;
            Volume24h = volume24h;
        }

        /// <summary>
        /// Возвращает строковое представление с тикером, курсом и направлением тренда.
        /// </summary>
        /// <returns>Форматированная строка.</returns>
        public override string ToString() =>
            $"[{Code}] {Name}: {CurrentRate:F2} USD  {Trend} {ChangePercent24h:+0.00;-0.00}%";
    }
}