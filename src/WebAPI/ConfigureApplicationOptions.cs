using Application.DTOs.Options;
using Domain.Constants;
using System.Diagnostics.CodeAnalysis;

namespace Application
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public static class ConfigureApplicationOptions
    {
        private const string JwtOptionsSectionName = "JWTOptions";
        public static IServiceCollection AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOption>(configuration.GetSection(JwtOptionsSectionName));

            return services;
        }
    }
}
