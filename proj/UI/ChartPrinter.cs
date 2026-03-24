using StockExchange.Shared;

namespace StockExchange.UI
{
    /// <summary>
    /// Модуль визуализации. Строит ASCII-график изменения курса валюты
    /// на основе истории котировок и выводит его в консоль.
    /// </summary>
    public class ChartPrinter
    {
        /// <summary>
        /// Выводит в консоль ASCII-график для указанной валюты.
        /// По оси X — временные точки (тики), по оси Y — значение курса.
        /// </summary>
        /// <param name="code">Код валюты для отображения в заголовке.</param>
        /// <param name="history">Список записей истории курса.</param>
        /// <param name="width">
        /// Максимальное количество точек на графике (ширина графика).
        /// По умолчанию 40.
        /// </param>
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