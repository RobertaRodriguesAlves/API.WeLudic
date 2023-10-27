using System.IO.Compression;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using WeLudic.Application;
using WeLudic.Application.Hubs;
using WeLudic.Infrastructure;
using WeLudic.Infrastructure.Data.Context;
using WeLudic.PublicApi.Extensions;
using WeLudic.PublicApi.Middlewares;
using WeLudic.Shared;
using WeLudic.Shared.Extensions;

try
{
    var builder = WebApplication.CreateBuilder(args);
    var logger = builder.Configuration.AddSerilog();

    builder.Services.Configure<KestrelServerOptions>(options => options.AddServerHeader = false);
    builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
    builder.Services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
    builder.Services.Configure<MvcNewtonsoftJsonOptions>(options => options.SerializerSettings.Configure());

    // Add services to the container.
    builder.Services.ConfigureAppSettings();
    builder.Services.AddInfrastructure();
    builder.Services.AddAppServices();
    builder.Services.AddWeLudicDbContext();

    builder.Services.AddSignalR();
    builder.Services.AddCors();
    builder.Services.AddHttpClient();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddSecurity(builder.Configuration, builder.Environment);

    builder.Services
        .AddControllers()
        .AddNewtonsoftJson(opt =>
        {
            opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            opt.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
            opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        });

    builder.Services.AddResponseCompression(opt => opt.Providers.Add<GzipCompressionProvider>());
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwagger(builder.Configuration);

    builder.WebHost.UseDefaultServiceProvider(opt =>
    {
        opt.ValidateScopes = builder.Environment.IsDevelopment();
        opt.ValidateOnBuild = true;
    });

    var connectionString = builder.Configuration.GetConnectionString("Database");
    builder.Services.AddHealthChecks(connectionString);
    builder.Host.UseSerilog(logger);

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
        app.UseDeveloperExceptionPage();

    app.UseSwaggerAndUI();
    app.UseHealthChecks("/health", new HealthCheckOptions
    {
        AllowCachingResponses = false,
        ResponseWriter = HealthCheckExtensions.WriteResponse
    });
    app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
    app.UseMiddleware<ErrorHandlerMiddleware>().UseMiddleware<SecurityHeadersMiddleware>();

    app.UseRouting();
    app.UseResponseCompression();
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapHub<AuthenticationHub>("/authentication");
    app.MapControllers();

    // Exibe os nomes das propriedades da validação sem os espaços.
    ValidatorOptions.Global.DisplayNameResolver = (_, member, _) => member?.Name;

    var mapper = app.Services.GetRequiredService<IMapper>();

    // Valida os mapeamentos, se existir alguma classe não mapeada corretamente, será lançada uma exceção.
    mapper.ConfigurationProvider.AssertConfigurationIsValid();

    // Cacheia os mapeamentos
    mapper.ConfigurationProvider.CompileMappings();

    // Verifica se existe alguma migração pendente a aplica se necessário.
    await using var scope = app.Services.CreateAsyncScope();
    await using var context = scope.ServiceProvider.GetRequiredService<WeLudicContext>();

    if ((await context.Database.GetPendingMigrationsAsync()).Any())
    {
        logger.Information("------ Creating and migrating the database...");
        await context.Database.MigrateAsync();
    }

    app.Run();
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong.");
}
finally
{
    Log.CloseAndFlush();
}
