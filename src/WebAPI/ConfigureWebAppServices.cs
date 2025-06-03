using Application.Models.Common;
using Asp.Versioning;
using Asp.Versioning.Conventions;
using Domain.Constants;
using System.Diagnostics.CodeAnalysis;

namespace WebAPI
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public static class ConfigureWebAppServices
    {
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
    }
}
