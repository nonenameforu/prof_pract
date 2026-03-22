using StockExchange.Market;

namespace StockExchange.UI
{
    // Интерактивный конвертер валют
    public class CurrencyConverter
    {
        private readonly ExchangeRateService _service;

        public CurrencyConverter(ExchangeRateService service)
        {
            _service = service;
        }

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