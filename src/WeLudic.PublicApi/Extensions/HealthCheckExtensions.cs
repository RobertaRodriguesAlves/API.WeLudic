using Ardalis.GuardClauses;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WeLudic.Shared.Extensions;
using WeLudic.Shared.HealthCheck;

namespace WeLudic.PublicApi.Extensions;

public static class HealthCheckExtensions
{
    public static IHealthChecksBuilder AddHealthChecks(this IServiceCollection services, string connectionString)
    {
        Guard.Against.NullOrWhiteSpace(connectionString, nameof(connectionString));
        return services.AddHealthChecks()
            .AddCheck<GCInfoHealthCheck>("GCInfoCheck", HealthStatus.Degraded, new string[1] { "memory" })
            .AddMySql(
                connectionString,
                "sql",
                HealthStatus.Degraded,
                new string[3] { "db", "sql", "sqlserver" });
    }

    public static Task WriteResponse(HttpContext context, HealthReport report)
    {
        context.Response.ContentType = "application/json";
        var value = new
        {
            Status = report.Status.ToString(),
            Duration = report.TotalDuration,
            Info = Enumerable.Select(report.Entries, (KeyValuePair<string, HealthReportEntry> e) => new
            {
                e.Key,
                e.Value.Description,
                e.Value.Duration,
                Status = Enum.GetName(typeof(HealthStatus), e.Value.Status),
                Error = e.Value.Exception?.Message,
                e.Value.Data
            }).ToList()
        };
        return context.Response.WriteAsync(value.ToJson());
    }
}