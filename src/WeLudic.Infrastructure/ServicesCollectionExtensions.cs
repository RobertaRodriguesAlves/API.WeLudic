using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using WeLudic.Infrastructure.Security.Interfaces;
using WeLudic.Infrastructure.Security.Services;
using WeLudic.Shared.Abstractions;

namespace WeLudic.Infrastructure;

[ExcludeFromCodeCoverage]
public static class ServicesCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICryptService, CryptService>();

        // Adicionando automaticamente todos os serviços no ASP.NET Core DI que herdam a interface IAppService
        // REF: https://github.com/khellang/Scrutor
        services
            .Scan(s => s.FromCallingAssembly()
            .AddClasses(c => c.AssignableTo<IRepository>())
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
