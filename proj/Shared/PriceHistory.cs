namespace StockExchange.Shared
{
    /// <summary>
    /// Представляет одну запись об изменении курса валюты в конкретный момент времени.
    /// Используется для построения графиков и аналитики.
    /// </summary>
    public class PriceHistory
    {
        /// <summary>Буквенный код валюты, к которой относится запись.</summary>
        public string CurrencyCode { get; set; }

        /// <summary>Зафиксированное значение курса в момент записи.</summary>
        public decimal Price { get; set; }

        /// <summary>Дата и время фиксации курса.</summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Инициализирует новую запись истории курса.
        /// </summary>
        /// <param name="code">Код валюты (например, "BTC").</param>
        /// <param name="price">Значение курса в момент записи.</param>
        public PriceHistory(string code, decimal price)
        {
            CurrencyCode = code;
            Price = price;
            Timestamp = DateTime.Now;
        }
    }
}