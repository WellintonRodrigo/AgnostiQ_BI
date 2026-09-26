using AgnostiQ_BI.Features.TimeSeriesAnalytics.Domain;

namespace AgnostiQ_BI.Features.TimeSeriesAnalytics.Services

{
    public class TimeSeriesDssEngine
    {
        public decimal CalculateWeightedMovingAverage(List<DataPoint> history)
        {
            if (history is null || history.Count == 0) return 0m;
            if (history.Count < 3) return history.Last().Value;

            var sorted = history.OrderByDescending(p => p.Timestamp).Take(3).ToList();

            // Multiplica pelos pesos e divide pela soma dos pesos (3 + 2 + 1 = 6)
            decimal weightedSum = (sorted[0].Value * 3) + (sorted[1].Value * 2) + (sorted[2].Value * 1);
            return Math.Round(weightedSum / 6m, 2);
        }

        // 🧠 Projeção Preditiva combinando o valor atual com a variação ponderada
        public decimal PredictNextValue(List<DataPoint> history)
        {
            if (history is null || history.Count == 0) return 0m;
            if (history.Count < 3) return history.Last().Value;

            var wma = CalculateWeightedMovingAverage(history);
            var lastValue = history.OrderBy(p => p.Timestamp).Last().Value;

            // Calcula o impulso de tendência com base no peso recente
            decimal trendDelta = lastValue - wma;
            return Math.Round(lastValue + trendDelta, 2);
        }
    }
}
