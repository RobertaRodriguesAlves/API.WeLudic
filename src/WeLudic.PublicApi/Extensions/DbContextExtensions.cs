using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using WeLudic.Infrastructure.Data.Context;
using WeLudic.Shared.AppSettings;

namespace WeLudic.PublicApi.Extensions;

public static class DbContextExtensions
{
    private static readonly string AssemblyName = typeof(Program).Assembly.GetName().Name;

    public static void AddWeLudicDbContext(this IServiceCollection services)
    {
        services.AddDbContext<WeLudicContext>((serviceProvider, options) =>
        {
            var connectionString = serviceProvider.GetRequiredService<IOptions<ConnectionStrings>>().Value;

            options.UseMySql(connectionString.Database, ServerVersion.AutoDetect(connectionString.Database), sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(AssemblyName);

                // Configura a resiliência da conexão: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 3);

                // Em ambiente de desenvolvimento é logado informações detalhadas.
                var environment = serviceProvider.GetRequiredService<IHostEnvironment>();
                if (environment.IsDevelopment())
                    options.EnableDetailedErrors().EnableSensitiveDataLogging();
            });

            var logger = serviceProvider.GetRequiredService<ILogger<WeLudicContext>>();

            // Log tentativas de repetição
            options.LogTo(
                filter: (eventId, _) => eventId.Id == CoreEventId.ExecutionStrategyRetrying,
                logger: (eventData) =>
                {
                    var retryEventData = eventData as ExecutionStrategyEventData;
                    var exceptions = retryEventData.ExceptionsEncountered;
                    var count = exceptions.Count;
                    var delay = retryEventData.Delay;
                    var message = exceptions[exceptions.Count - 1].Message;
                    logger.LogWarning("------ Retry #{Count} with delay {Delay} due to error: {Message}", count, delay, message);
                });
        });
    }
}
