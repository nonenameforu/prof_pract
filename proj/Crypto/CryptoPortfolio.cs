namespace StockExchange.Crypto
{
    // Портфель криптовалют пользователя
    public class CryptoPortfolio
    {
        private readonly Dictionary<string, decimal> _holdings = new();

        public void Buy(string code, decimal amount)
        {
            if (_holdings.ContainsKey(code))
                _holdings[code] += amount;
            else
                _holdings[code] = amount;

            Console.WriteLine($"[ПОКУПКА] {amount} {code} добавлено в портфель.");
        }

        public void Sell(string code, decimal amount)
        {
            if (!_holdings.ContainsKey(code) || _holdings[code] < amount)
                throw new InvalidOperationException($"Недостаточно {code} в портфеле.");

            _holdings[code] -= amount;
            Console.WriteLine($"[ПРОДАЖА] {amount} {code} продано.");
        }

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

        public void Print()
        {
            Console.WriteLine("=== Портфель ===");
            foreach (var (code, qty) in _holdings)
                Console.WriteLine($"  {code}: {qty}");
        }
    }
}