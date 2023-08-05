using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using WeLudic.Shared.AppSettings;
using WeLudic.Shared.Extensions;

namespace WeLudic.Shared;

[ExcludeFromCodeCoverage]
public static class ServicesCollectionExtensions
{
    public static void ConfigureAppSettings(this IServiceCollection services)
        => services
            .AddOptionsWithNonPublicProperties<ConnectionStrings>(nameof(ConnectionStrings))
            .AddOptionsWithNonPublicProperties<SecuritySettings>(nameof(SecuritySettings));
}
