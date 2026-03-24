using StockExchange.Market;

namespace StockExchange.UI
{
    /// <summary>
    /// Интерактивный конвертер валют. Запрашивает у пользователя
    /// исходную валюту, целевую валюту и сумму, затем выводит результат
    /// конвертации по текущему курсу.
    /// </summary>
    public class CurrencyConverter
    {
        private readonly ExchangeRateService _service;

        /// <summary>
        /// Инициализирует конвертер с привязкой к сервису курсов.
        /// </summary>
        /// <param name="service">Сервис фиатных валют.</param>
        public CurrencyConverter(ExchangeRateService service)
        {
            _service = service;
        }

        /// <summary>
        /// Запускает интерактивный режим конвертации в консоли.
        /// Пользователь последовательно вводит код исходной валюты,
        /// код целевой валюты и сумму. Результат выводится в консоль.
        /// </summary>
        public void RunInteractive()
        {
            Console.WriteLine("\n=== Конвертер валют ===");
            Console.Write("Из (USD/RUB/CNY): ");
            string from = Console.ReadLine()?.ToUpper() ?? "USD";

            Console.Write("В   (USD/RUB/CNY): ");
            string to = Console.ReadLine()?.ToUpper() ?? "RUB";

            Console.Write("Сумма: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                decimal result = _service.Convert(from, to, amount);
                Console.WriteLine($"\nРезультат: {amount} {from} = {result:F4} {to}");
            }
            else
            {
                Console.WriteLine("Ошибка: некорректная сумма.");
            }
        }
    }
}