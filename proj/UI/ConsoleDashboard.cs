using StockExchange.Market;
using StockExchange.Crypto;

namespace StockExchange.UI
{
    /// <summary>
    /// Консольный дашборд. Отображает актуальные котировки фиатных валют
    /// и криптовалют в виде форматированной таблицы в консоли.
    /// </summary>
    public class ConsoleDashboard
    {
        private readonly ExchangeRateService _fiat;
        private readonly CryptoMarketService _crypto;

        /// <summary>
        /// Инициализирует дашборд с привязкой к сервисам данных.
        /// </summary>
        /// <param name="fiat">Сервис фиатных валют.</param>
        /// <param name="crypto">Сервис криптовалют.</param>
        public ConsoleDashboard(ExchangeRateService fiat, CryptoMarketService crypto)
        {
            _fiat = fiat;
            _crypto = crypto;
        }

        /// <summary>
        /// Очищает консоль и выводит актуальную таблицу котировок:
        /// сначала фиатные валюты, затем криптовалюты с индикатором тренда.
        /// </summary>
        public void Render()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║          ФОНДОВАЯ БИРЖА  v1.0                ║");
            Console.WriteLine($"║  {DateTime.Now:dd.MM.yyyy  HH:mm:ss}        ║");
            Console.WriteLine("╠══════════════════════════════════════════════╣");
            Console.WriteLine("║  ФИАТНЫЕ ВАЛЮТЫ                              ║");

            foreach (var c in _fiat.GetAll())
                Console.WriteLine($"║  {c.Code,-4} {c.Name,-16} {c.CurrentRate,10:F4} USD     ║");

            Console.WriteLine("╠══════════════════════════════════════════════╣");
            Console.WriteLine("║  КРИПТОВАЛЮТЫ                                ║");

            foreach (var c in _crypto.GetAll())
                Console.WriteLine($"║  {c.Code,-4} {c.Name,-16} {c.CurrentRate,10:F2} USD  {c.Trend}  ║");

            Console.WriteLine("╚══════════════════════════════════════════════╝");
        }
    }
}