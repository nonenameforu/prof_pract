using StockExchange.Shared;

namespace StockExchange.Market
{
    /// <summary>
    /// Представляет фиатную (государственную) валюту.
    /// Наследует базовую модель <see cref="Currency"/> и расширяет её
    /// сведениями о стране и символе валюты.
    /// Поддерживаемые валюты: USD, RUB, CNY.
    /// </summary>
    public class FiatCurrency : Currency
    {
        /// <summary>Название страны, выпустившей валюту.</summary>
        public string Country { get; set; }

        /// <summary>Графический символ валюты (например, $, ₽, ¥).</summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр фиатной валюты.
        /// </summary>
        /// <param name="code">Код валюты по ISO 4217 (например, "USD").</param>
        /// <param name="name">Полное наименование валюты.</param>
        /// <param name="country">Страна-эмитент.</param>
        /// <param name="symbol">Символ валюты.</param>
        /// <param name="rate">Начальный курс относительно USD.</param>
        public FiatCurrency(string code, string name, string country, string symbol, decimal rate)
            : base(code, name, rate)
        {
            Country = country;
            Symbol = symbol;
        }
    }
}