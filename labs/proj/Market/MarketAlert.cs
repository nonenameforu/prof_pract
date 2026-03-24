namespace StockExchange.Market
{
    /// <summary>
    /// Модуль уведомлений: срабатывает когда курс валюты
    /// достигает заданного порогового значения.
    /// </summary>
    public class MarketAlert
    {
        /// <summary>Код валюты, за которой ведётся наблюдение.</summary>
        public string CurrencyCode { get; set; }

        /// <summary>Пороговое значение курса для срабатывания уведомления.</summary>
        public decimal ThresholdRate { get; set; }

        /// <summary>
        /// Направление срабатывания.
        /// <c>true</c> — уведомить при росте выше порога,
        /// <c>false</c> — уведомить при падении ниже порога.
        /// </summary>
        public bool TriggerAbove { get; set; }

        /// <summary>Признак того, что уведомление уже сработало.</summary>
        public bool IsTriggered { get; set; } = false;

        /// <summary>
        /// Инициализирует новое уведомление.
        /// </summary>
        /// <param name="code">Код валюты для отслеживания.</param>
        /// <param name="threshold">Пороговое значение курса.</param>
        /// <param name="triggerAbove">
        /// <c>true</c> — сработать при достижении или превышении порога,
        /// <c>false</c> — сработать при падении до порога или ниже.
        /// </param>
        public MarketAlert(string code, decimal threshold, bool triggerAbove)
        {
            CurrencyCode = code;
            ThresholdRate = threshold;
            TriggerAbove = triggerAbove;
        }

        /// <summary>
        /// Проверяет текущий курс относительно порога и при необходимости
        /// выводит уведомление в консоль.
        /// </summary>
        /// <param name="currentRate">Текущее значение курса.</param>
        /// <returns><c>true</c> если порог достигнут, иначе <c>false</c>.</returns>
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