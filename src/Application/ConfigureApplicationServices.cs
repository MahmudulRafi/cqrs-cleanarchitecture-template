using Application.Features.Bookings.Services;
using Application.Features.Events.Services;
using Application.Features.Organizations.Queries.GetAllOrganization;
using Application.Features.Organizations.Queries.GetOrganizationById;
using Application.Features.Organizations.Services;
using Application.Middlewares;
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
            //services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IOrganizationService, OrganizationService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllOrganizationQuery).GetTypeInfo().Assembly));
            services.AddValidatorsFromAssemblyContaining<GetOrganizationByIdQueryValidator>(includeInternalTypes: true);

            //services.AddAutoMapper(typeof(OrganizationMappingProfiles).Assembly);

            return services;
        }

        public static IServiceCollection AddMiddlewares(this IServiceCollection services)
        {
            services.AddTransient<GlobalExceptionHandlerMiddleware>();
            
            return services;
        }
    }
}
