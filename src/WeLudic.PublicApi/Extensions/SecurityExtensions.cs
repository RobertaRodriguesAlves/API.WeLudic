using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using WeLudic.Shared.AppSettings;
using WeLudic.Shared.Extensions;

namespace WeLudic.PublicApi.Extensions;

public static class SecurityExtensions
{
    public static void AddSecurity(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        var settings = configuration.GetOptions<SecuritySettings>(nameof(SecuritySettings));

        services
            .AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearerOptions =>
            {
                // RequiredHttpsMetadata deve estar sempre habilitado no ambiente de produção.
                bearerOptions.RequireHttpsMetadata = environment.IsProduction();
                bearerOptions.SaveToken = true;
                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey)),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = settings.Audience,
                    ValidIssuer = settings.Issuer
                };
            });

        services.AddAuthorization(authOptions =>
        {
            var authorizationPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();

            authOptions.AddPolicy("Bearer", authorizationPolicy);
            authOptions.FallbackPolicy = authorizationPolicy;
        });

        services.AddSignalR();
    }
}