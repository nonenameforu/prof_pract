namespace StockExchange.Shared
{
    // Базовая модель валюты — используется во всех модулях
    public class Currency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal CurrentRate { get; set; } // курс относительно USD
        public DateTime LastUpdated { get; set; }

        public Currency(string code, string name, decimal rate)
        {
            Code = code;
            Name = name;
            CurrentRate = rate;
            LastUpdated = DateTime.Now;
        }

        public override string ToString() =>
            $"[{Code}] {Name}: {CurrentRate:F4} USD  (обновлено: {LastUpdated:HH:mm:ss})";
    }
}