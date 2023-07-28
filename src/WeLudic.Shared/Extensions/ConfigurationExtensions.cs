using Microsoft.Extensions.Configuration;

namespace WeLudic.Shared.Extensions;

public static class ConfigurationExtensions
{
    public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string configSectionPath) where TOptions : class
    {
        return configuration.GetSection(configSectionPath).Get<TOptions>(delegate (BinderOptions options)
        {
            options.BindNonPublicProperties = true;
        });
    }
}
