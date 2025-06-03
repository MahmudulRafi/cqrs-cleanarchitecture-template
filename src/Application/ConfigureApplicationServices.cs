using Application.Features.Organizations.Queries.GetAllOrganization;
using Application.Features.Organizations.Queries.GetOrganizationById;
using Application.Interfaces.Organizations;
using Application.Middlewares;
using Application.Services;
using Domain.Constants;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Application
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public static class ConfigureApplicationServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationService, OrganizationService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllOrganizationQuery).GetTypeInfo().Assembly));
            services.AddValidatorsFromAssemblyContaining<GetOrganizationByIdQueryValidator>(includeInternalTypes: true);

            return services;
        }

        public static IServiceCollection AddMiddlewares(this IServiceCollection services)
        {
            services.AddTransient<GlobalExceptionHandlerMiddleware>();
            
            return services;
        }
    }
}
