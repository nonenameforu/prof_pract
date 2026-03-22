using StockExchange.Shared;

namespace StockExchange.UI
{
    // Консольный ASCII-график изменения курса
    public class ChartPrinter
    {
        public void Print(string code, List<PriceHistory> history, int width = 40)
        {
            if (history.Count < 2)
            {
                Console.WriteLine("Недостаточно данных для построения графика.");
                return;
            }

            var points = history.TakeLast(width).ToList();
            decimal min = points.Min(h => h.Price);
            decimal max = points.Max(h => h.Price);
            decimal range = max - min;
            int rows = 8;

            Console.WriteLine($"\n=== График {code} (последние {points.Count} точек) ===");
            Console.WriteLine($"  Макс: {max:F4}   Мин: {min:F4}");

            for (int row = rows; row >= 0; row--)
            {
                decimal level = min + (range == 0 ? 0 : range * row / rows);
                Console.Write($"{level,9:F4} |");
                foreach (var p in points)
                {
                    decimal normalized = range == 0 ? 0 : (p.Price - min) / range * rows;
                    Console.Write(normalized >= row ? "█" : " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("          " + new string('─', points.Count));
        }
    }
}