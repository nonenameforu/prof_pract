namespace StockExchange.Shared
{
    /// <summary>
    /// Базовая модель валюты. Является родительским классом для
    /// <see cref="StockExchange.Market.FiatCurrency"/> и
    /// <see cref="StockExchange.Crypto.CryptoCurrency"/>.
    /// </summary>
    public class Currency
    {
        /// <summary>Буквенный код валюты (например, USD, BTC).</summary>
        public string Code { get; set; }

        /// <summary>Полное наименование валюты.</summary>
        public string Name { get; set; }

        /// <summary>Текущий курс валюты относительно доллара США (USD).</summary>
        public decimal CurrentRate { get; set; }

        /// <summary>Дата и время последнего обновления курса.</summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Currency"/>.
        /// </summary>
        /// <param name="code">Буквенный код валюты (например, "USD").</param>
        /// <param name="name">Полное наименование валюты.</param>
        /// <param name="rate">Начальный курс относительно USD.</param>
        public Currency(string code, string name, decimal rate)
        {
            Code = code;
            Name = name;
            CurrentRate = rate;
            LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// Возвращает строковое представление валюты с кодом, названием и текущим курсом.
        /// </summary>
        /// <returns>Форматированная строка с данными валюты.</returns>
        public override string ToString() =>
            $"[{Code}] {Name}: {CurrentRate:F4} USD  (обновлено: {LastUpdated:HH:mm:ss})";
    }
}