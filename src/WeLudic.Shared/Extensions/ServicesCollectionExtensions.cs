using Microsoft.Extensions.DependencyInjection;

namespace WeLudic.Shared.Extensions;

public static class ServicesCollectionExtensions
{
    /// <summary>
    /// Adiciona uma classe que representa uma seção do AppSettings.
    /// </summary>
    /// <typeparam name="TOptions">O tipo de opção a ser configurado</typeparam>
    /// <param name="services"></param>
    /// <param name="configSectionPath">O nome da seção no AppSettings</param>
    /// <returns></returns>
    public static IServiceCollection AddOptionsWithNonPublicProperties<TOptions>(this IServiceCollection services, string configSectionPath) where TOptions : class
    {
        var optionsBuilder = services
            .AddOptions<TOptions>()
            .BindConfiguration(configSectionPath, options => options.BindNonPublicProperties = true)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return optionsBuilder.Services;
    }
}
