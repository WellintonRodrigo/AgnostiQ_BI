namespace AgnostiQ_BI.Features.TimeSeriesAnalytics.Domain
{

    public record DataPoint(
        DateTime Timestamp,
        decimal Value
        );
    

    
    public class TimeSeriesMetric
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;     // ex: "Preço do Diesel", "Ações PETR4", "Vendas"
        public string Unit { get; set; } = string.Empty;     // ex: "R$", "L", "Unidades", "%"
        public string Category { get; set; } = string.Empty; // ex: "Commodities", "Financeiro", "Estoque"

        // ⚡ Salvo como documento JSON nativo no banco
        public List<DataPoint> History { get; set; } = [];
    }
}
