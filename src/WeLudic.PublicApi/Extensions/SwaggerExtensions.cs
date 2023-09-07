using Microsoft.OpenApi.Models;

namespace WeLudic.PublicApi.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        var path = configuration.GetValue<string>("Business:Url");

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "WeLudic API",
                Contact = new OpenApiContact
                {
                    Name = "WeLudic",
                    Url = new Uri(path)
                }
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization Header - utilizado com Bearer Authentication. \r\n\r\n" +
                              "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                              "Exemplo (informar sem as aspas): 'Bearer 254kdugs#'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            options.ResolveConflictingActions(apiDescription => apiDescription.FirstOrDefault());
        });

        services.AddSwaggerGenNewtonsoftSupport();
    }

    public static void UseSwaggerAndUI(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(opt => opt.DisplayRequestDuration());
    }
}
