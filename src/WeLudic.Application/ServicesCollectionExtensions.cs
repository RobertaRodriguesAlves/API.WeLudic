using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Application;

[ExcludeFromCodeCoverage]
public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        // Adicionando automaticamente todos os serviços no ASP.NET Core DI que herdam a interface IAppService
        // REF: https://github.com/khellang/Scrutor
        services
            .Scan(s => s.FromCallingAssembly()
            .AddClasses(c => c.AssignableTo<IAppService>())
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
