using Microsoft.EntityFrameworkCore;
using AgnostiQ_BI.Features.TimeSeriesAnalytics.Data;
using AgnostiQ_BI.Features.TimeSeriesAnalytics.Domain;
using AgnostiQ_BI.Features.TimeSeriesAnalytics.Services;

namespace AgnostiQ_BI.Features.TimeSeriesAnalytics.Endpoints
{
    public static class TimeSeriesEndpoints
    {
        public static void MapTimeSeriesEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/time-series").WithTags("TimeSeriesAnalytics");

            // ⚡ GET: Listar todas as métricas gravadas no MySQL
            group.MapGet("/", async (AppDbContext db) =>
                await db.TimeSeriesMetrics.ToListAsync());

            // 🧠 GET: Calcular análise preditiva WMA para uma métrica específica
            group.MapGet("/{id:guid}/predict", async (Guid id, AppDbContext db, TimeSeriesDssEngine engine) =>
            {
                var metric = await db.TimeSeriesMetrics.FindAsync(id);
                if (metric is null) return Results.NotFound("Métrica não encontrada.");

                var wma = engine.CalculateWeightedMovingAverage(metric.History);
                var prediction = engine.PredictNextValue(metric.History);

                return Results.Ok(new
                {
                    MetricId = metric.Id,
                    MetricName = metric.Name,
                    Unit = metric.Unit,
                    CurrentValue = metric.History.LastOrDefault()?.Value ?? 0m,
                    WeightedMovingAverage = wma,
                    PredictedNextValue = prediction
                });
            });

            // 🚀 POST: Cadastrar nova métrica com histórico inicial
            group.MapPost("/", async (TimeSeriesMetric metric, AppDbContext db) =>
            {
                db.TimeSeriesMetrics.Add(metric);
                await db.SaveChangesAsync();
                return Results.Created($"/api/time-series/{metric.Id}", metric);
            });
        }
    }
}
