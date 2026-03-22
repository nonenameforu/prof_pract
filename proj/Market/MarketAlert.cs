namespace StockExchange.Market
{
    // Уведомление при достижении порогового значения курса
    public class MarketAlert
    {
        public string CurrencyCode { get; set; }
        public decimal ThresholdRate { get; set; }
        public bool TriggerAbove { get; set; }  // true = сработать при росте выше порога
        public bool IsTriggered { get; set; } = false;

        public MarketAlert(string code, decimal threshold, bool triggerAbove)
        {
            CurrencyCode = code;
            ThresholdRate = threshold;
            TriggerAbove = triggerAbove;
        }

        public bool Check(decimal currentRate)
        {
            IsTriggered = TriggerAbove
                ? currentRate >= ThresholdRate
                : currentRate <= ThresholdRate;

            if (IsTriggered)
                Console.WriteLine($"[ALERT] {CurrencyCode} достиг порога {ThresholdRate:F4}!");

            return IsTriggered;
        }
    }
}