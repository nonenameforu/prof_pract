using StockExchange.Market;
using StockExchange.Crypto;
using StockExchange.UI;

class Program
{
    static void Main(string[] args)
    {
        var fiatService = new ExchangeRateService();
        var cryptoService = new CryptoMarketService();
        var dashboard = new ConsoleDashboard(fiatService, cryptoService);
        var converter = new CurrencyConverter(fiatService);
        var chart = new ChartPrinter();

        Console.WriteLine("Запуск биржи [MARKET MODULE]... симулируем 10 тиков.\n");

        for (int i = 0; i < 10; i++)
        {
            fiatService.SimulateTick();
            cryptoService.SimulateTick();
            Thread.Sleep(200);
        }

        dashboard.Render();
        chart.Print("BTC", cryptoService.GetHistory("BTC"));
        chart.Print("RUB", fiatService.GetHistory("RUB"));
        converter.RunInteractive();
    }
}