using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AgnostiQ_BI.Features.TimeSeriesAnalytics.Domain;

namespace AgnostiQ_BI.Features.TimeSeriesAnalytics.Data
{
    public class TimeSeriesMetricConfiguration
    {
        public void Configure(EntityTypeBuilder<TimeSeriesMetric> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.Unit)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.History)
            .HasColumnType("json")
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => JsonSerializer.Deserialize<List<DataPoint>>(v, (JsonSerializerOptions?)null) ?? new List<DataPoint>()
            );
        }
    }
}
