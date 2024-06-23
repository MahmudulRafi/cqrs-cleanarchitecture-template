using Application.DTOs.Options;
using Asp.Versioning;
using Asp.Versioning.Conventions;
using Domain.Constants;
using Infrastructure.Interceptors;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;
using WebAPI;

namespace Application
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public static class ConfigureServices
    {
        private const string JwtOptionsSectionName = "JWTOptions";
        public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure options

            services.Configure<JwtOption>(configuration.GetSection(JwtOptionsSectionName));

            return services;
        }

        public static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(
                   options =>
                   {
                       options.DefaultApiVersion = new ApiVersion(1.0);
                       options.AssumeDefaultVersionWhenUnspecified = true;
                       options.ReportApiVersions = true;
                       options.ApiVersionReader = ApiVersionReader.Combine(
                              new UrlSegmentApiVersionReader(),
                              new QueryStringApiVersionReader("api-version"),
                              new HeaderApiVersionReader("X-Version"),
                              new MediaTypeApiVersionReader("x-version"));
                   })
               .AddMvc(
                   options =>
                   {
                       options.Conventions.Add(new VersionByNamespaceConvention());
                   })
               .AddApiExplorer(setup =>
               {
                   setup.GroupNameFormat = "'v'VVV";
                   setup.SubstituteApiVersionInUrl = true;
               });

            return services;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();

            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }

        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<UpdateAuditableEntityInterceptor>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            return services;
        }
    }
}
