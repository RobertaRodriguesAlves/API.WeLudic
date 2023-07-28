using System.Reflection;
using Microsoft.OpenApi.Models;

namespace WeLudic.PublicApi.Extensions;

public static class SwaggerExtensions
{
    private const string Path = "https://weludic.org";

    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "WeLudic API",
                Contact = new OpenApiContact
                {
                    Name = "WeLudic",
                    Url = new Uri(Path)
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

            //Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath, true);
        });

        services.AddSwaggerGenNewtonsoftSupport();
    }

    public static void UseSwaggerAndUI(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(opt => opt.DisplayRequestDuration());
    }
}
