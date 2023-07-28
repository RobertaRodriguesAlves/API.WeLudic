using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WeLudic.Shared.HealthCheck;

public sealed class GCInfoHealthCheck : IHealthCheck
{
    private const long Threshold = 1024L * 1024L * 1024L;
    private const string Description = "O status é degradado se a quantidade bytes alocados for >= 1gb";
    private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var allocatedMemory = GC.GetTotalMemory(forceFullCollection: false);

        var memoryInfo = GC.GetGCMemoryInfo();

        var data = new Dictionary<string, object>
        {
            { "Allocated", SizeSuffix(allocatedMemory) },
            { "TotalAvailableMemoryBytes", SizeSuffix(memoryInfo.TotalAvailableMemoryBytes) },
            { "Gen0Collections", GC.CollectionCount(0) },
            { "Gen1Collections", GC.CollectionCount(1) },
            { "Gen2Collections", GC.CollectionCount(2) }
        };

        // Report failure if the allocated memory is >= the threshold.
        var healthStatus = allocatedMemory >= Threshold ? context.Registration.FailureStatus : HealthStatus.Healthy;
        return Task.FromResult(new HealthCheckResult(healthStatus, Description, data: data));
    }

    private static string SizeSuffix(long allocatedMemory, int decimalPlaces = 1)
    {
        if (allocatedMemory < 0)
            return "-" + SizeSuffix(-allocatedMemory, decimalPlaces);

        if (allocatedMemory == 0)
            return string.Format("{0:n" + decimalPlaces + "} bytes", 0);

        // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
        var mag = (int)Math.Log(allocatedMemory, 1024);

        // [i.e. the number of bytes in the unit corresponding to mag]
        var adjustedSize = (decimal)allocatedMemory / (1L << (mag * 10));

        // make adjustment when the value is large enough that
        // it would round up to 1000 or more
        if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
        {
            mag++;
            adjustedSize /= 1024;
        }

        return string.Format("{0:n" + decimalPlaces + "} {1}", adjustedSize, SizeSuffixes[mag]);
    }
}