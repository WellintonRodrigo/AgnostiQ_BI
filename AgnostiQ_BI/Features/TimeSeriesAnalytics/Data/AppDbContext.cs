using AgnostiQ_BI.Features.TimeSeriesAnalytics.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgnostiQ_BI.Features.TimeSeriesAnalytics.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TimeSeriesMetric> TimeSeriesMetrics => Set<TimeSeriesMetric>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🧠 Aplica automaticamente as configurações de mapeamento de todas as Features
           modelBuilder.Ignore<DataPoint>(); // Ignora a classe DataPoint, pois ela é usada apenas como parte do TimeSeriesMetric

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
