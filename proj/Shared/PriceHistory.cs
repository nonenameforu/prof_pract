namespace StockExchange.Shared
{
    // Запись об изменении курса в конкретный момент времени
    public class PriceHistory
    {
        public string CurrencyCode { get; set; }
        public decimal Price { get; set; }
        public DateTime Timestamp { get; set; }

        public PriceHistory(string code, decimal price)
        {
            CurrencyCode = code;
            Price = price;
            Timestamp = DateTime.Now;
        }
    }
}