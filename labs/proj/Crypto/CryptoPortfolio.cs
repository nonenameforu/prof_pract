namespace StockExchange.Crypto
{
    /// <summary>
    /// Портфель криптовалют пользователя.
    /// Позволяет покупать и продавать криптовалюты, а также
    /// рассчитывать суммарную стоимость портфеля по текущим курсам.
    /// </summary>
    public class CryptoPortfolio
    {
        private readonly Dictionary<string, decimal> _holdings = new();

        /// <summary>
        /// Добавляет указанное количество криптовалюты в портфель.
        /// Если валюта уже есть в портфеле — количество увеличивается.
        /// </summary>
        /// <param name="code">Тикер криптовалюты.</param>
        /// <param name="amount">Количество для покупки.</param>
        public void Buy(string code, decimal amount)
        {
            if (_holdings.ContainsKey(code))
                _holdings[code] += amount;
            else
                _holdings[code] = amount;

            Console.WriteLine($"[ПОКУПКА] {amount} {code} добавлено в портфель.");
        }

        /// <summary>
        /// Продаёт указанное количество криптовалюты из портфеля.
        /// </summary>
        /// <param name="code">Тикер криптовалюты.</param>
        /// <param name="amount">Количество для продажи.</param>
        /// <exception cref="InvalidOperationException">
        /// Выбрасывается если в портфеле недостаточно средств.
        /// </exception>
        public void Sell(string code, decimal amount)
        {
            if (!_holdings.ContainsKey(code) || _holdings[code] < amount)
                throw new InvalidOperationException($"Недостаточно {code} в портфеле.");

            _holdings[code] -= amount;
            Console.WriteLine($"[ПРОДАЖА] {amount} {code} продано.");
        }

        /// <summary>
        /// Рассчитывает суммарную стоимость портфеля в долларах США
        /// по текущим котировкам.
        /// </summary>
        /// <param name="service">Сервис криптовалют для получения актуальных курсов.</param>
        /// <returns>Суммарная стоимость портфеля в USD.</returns>
        public decimal GetTotalValueUsd(CryptoMarketService service)
        {
            decimal total = 0;
            foreach (var (code, qty) in _holdings)
            {
                var crypto = service.GetAll().FirstOrDefault(c => c.Code == code);
                if (crypto != null) total += qty * crypto.CurrentRate;
            }
            return total;
        }

        /// <summary>
        /// Выводит содержимое портфеля в консоль.
        /// </summary>
        public void Print()
        {
            Console.WriteLine("=== Портфель ===");
            foreach (var (code, qty) in _holdings)
                Console.WriteLine($"  {code}: {qty}");
        }
    }
}